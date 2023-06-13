using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Newtonsoft.Json.Linq;

using Newtonsoft.Json;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Customer;
using SellWebsite.Utility;
using SellWebsite.Utility.Helpers;

using static System.Net.WebRequestMethods;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaypalSettings _paypalSettings;


        public ShoppingCartController(IUnitOfWork unitOfWork, IOptions<PaypalSettings> paypalSettings)
        {
            _unitOfWork = unitOfWork;
            _paypalSettings = paypalSettings.Value;
        }
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; } = new();

        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            if (claimIdentity.Name != null)
            {
                var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var listCarts = _unitOfWork.ShoppingCart.GetAll(p => p.ApplicationUserId == userId, x => x.Product).ToList();

                ShoppingCartVM = new()
                {
                    Carts = listCarts,
                    OrderHeader = new OrderHeader()
                    {
                        OrderTotal = (Double)listCarts.Sum(p => p.Product.Price * p.Quantity),
                        Discount = 0,
                    }
                };

                ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
                ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
                ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
                ShoppingCartVM.OrderHeader.Country = ShoppingCartVM.OrderHeader.ApplicationUser.Country;
                ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
                ShoppingCartVM.OrderHeader.Zipcode = ShoppingCartVM.OrderHeader.ApplicationUser.Zipcode;
                ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
                ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            }
            else
            {
                var sessionShopCart = HttpContext.Session.GetString(SD.SessionShopingCarts);
                if (sessionShopCart != null)
                {
                    var listCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString(SD.SessionShopingCarts));
                    ShoppingCartVM = new()
                    {
                        Carts = listCarts,
                        OrderHeader = new OrderHeader()
                        {
                            OrderTotal = (Double)listCarts.Sum(p => p.Product.Price * p.Quantity),
                            Discount = 0,
                        }
                    };
                }
                else
                {
                    ShoppingCartVM = new()
                    {
                        Carts = new(),
                        OrderHeader = new OrderHeader()
                        {
                            OrderTotal = 0,
                            Discount = 0,
                        }
                    };
                }
            }

            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Index")]
        [Authorize]
        public async Task<IActionResult> IndexPOST()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            ShoppingCartVM.Carts = _unitOfWork.ShoppingCart.GetAll(p => p.ApplicationUserId == userId, x => x.Product).ToList();

            if (ShoppingCartVM.Carts.Count != 0)
            {
                ShoppingCartVM.OrderHeader.OrderTotal = ShoppingCartVM.OrderHeader.OrderTotal - ShoppingCartVM.OrderHeader.Discount;

                ShoppingCartVM.OrderHeader.OrderTime = DateTime.Now;
                ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

                var userData = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
                if (string.IsNullOrEmpty(userData.PhoneNumber))
                {
                    userData.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
                }

                ShoppingCartVM.OrderHeader.ApplicationUser = userData;
                //

                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;

                _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
                _unitOfWork.Save();

                foreach (var cart in ShoppingCartVM.Carts)
                {
                    var orderDetail = new OrderDetail()
                    {
                        ProductId = cart.ProductId,
                        OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                        Count = cart.Quantity,
                        Price = (double)cart.Product.Price * cart.Quantity,
                    };
                    _unitOfWork.OrderDetail.Add(orderDetail);
                    _unitOfWork.Save();
                }

                //payment :____(
                try
                {
                    var apiContext = await PaypalGetAccessTokenHelper.GetPayPalAccessTokenAsync(_paypalSettings);

                    PayPalPaymentCreatedResponse createdPayment = await CreatePaypalPaymentAsync(apiContext, ShoppingCartVM.OrderHeader.Id);

                    var approval_url = createdPayment.links.First(x => x.rel == "approval_url").href;
                    _unitOfWork.OrderHeader.UpdatePaypalPaymentId(ShoppingCartVM.OrderHeader.Id, createdPayment.id, "4MBX7FG6TB5NE");
                    _unitOfWork.Save();

                    return Redirect(approval_url);

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        }
        [Authorize]
        public async Task<IActionResult> OrderConfirmationAsync(int id)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            try
            {
                var apiContext = await PaypalGetAccessTokenHelper.GetPayPalAccessTokenAsync(_paypalSettings);

                PayPalPaymentExecutedResponse executedPayment = await ExecutePaypalPaymentAsync(apiContext, id);
                if (executedPayment.payer.status == SD.PaypalVERIFIED)
                {
                    var listCarts = _unitOfWork.ShoppingCart.GetAll(p => p.ApplicationUserId == userId, x => x.Product).ToList();

                    //Mua hàng xong thì clear cái giỏ hàng đi
                    _unitOfWork.ShoppingCart.RemoveRange(listCarts);
                    //Clear cả cái session mới thêm vào nữa :_) bug mò cả ngày mới ra
                    HttpContext.Session.Remove(SD.SessionCart);

                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    _unitOfWork.OrderHeader.Get(p => p.Id == id).PaymentDate = DateTime.Now;
                    _unitOfWork.OrderHeader.Get(p => p.Id == id).PaymentDueDate = DateTime.Now;
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.PaymentRejected, SD.PaymentRejected);
                    _unitOfWork.OrderHeader.Get(p => p.Id == id).PaymentDate = DateTime.Now;
                    _unitOfWork.OrderHeader.Get(p => p.Id == id).PaymentDueDate = DateTime.Now;
                    _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
                ///
                throw;
            }
            return View(id);
        }

        #region Paypal

        public async Task<PayPalPaymentCreatedResponse> CreatePaypalPaymentAsync(PayPalAccessToken accessToken, int orderId)
        {
            var httpUri = PaypalGetAccessTokenHelper.GetPaypalHttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/payments/payment");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            //https://localhost:7196/
            var domain = Request.Scheme + "://" + Request.Host;
            var returnUrl = $"{domain}/Customer/ShoppingCart/OrderConfirmation?id={orderId}";
            var cancelUrl = $"{domain}/Customer/ShoppingCart/Index";

            var orderHeader = _unitOfWork.OrderHeader.Get(p => p.Id == orderId);

            var payment = JObject.FromObject(new
            {
                intent = "sale",
                redirect_urls = new
                {
                    return_url = returnUrl,
                    cancel_url = cancelUrl,
                },
                payer = new { payment_method = "paypal" },
                transactions = JArray.FromObject(new[]
    {
                    new
                    {
                        amount = new
                        {
                            total = orderHeader.OrderTotal,
                            currency = "USD"
                        }
                    }
                })
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpUri.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentCreatedResponse paypalPaymentCreated = JsonConvert.DeserializeObject<PayPalPaymentCreatedResponse>(content);
            return paypalPaymentCreated;
        }
        public async Task<PayPalPaymentExecutedResponse> ExecutePaypalPaymentAsync(PayPalAccessToken accessToken, int orderId)
        {
            var httpUri = PaypalGetAccessTokenHelper.GetPaypalHttpClient();
            var orderHeader = _unitOfWork.OrderHeader.Get(p => p.Id == orderId);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"v1/payments/payment/{orderHeader.PaymentId}/execute");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                payer_id = orderHeader.PayerId
            });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpUri.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentExecutedResponse executedPayment = JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);

            return executedPayment;
        }

        #endregion


        #region Cart Options
        public IActionResult Remove(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            _unitOfWork.ShoppingCart.Remove(productInCart);

            HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == productInCart.ApplicationUserId).Count() - 1);

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            if (productInCart.Quantity <= 1)
            {
                //Session cho số lượng sản phẩm trong cart thành 0 nếu sản phẩm bị xóa hoặc số lượng = 0
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == productInCart.ApplicationUserId).Count() - 1);

                _unitOfWork.ShoppingCart.Remove(productInCart);
            }
            else
            {
                productInCart.Quantity -= 1;
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Plus(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            if (productInCart.Quantity >= 999)
            {
            }
            else
            {
                productInCart.Quantity += 1;
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }

}
