using System;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Customer;
using SellWebsite.Utility;
using SellWebsite.Utility.Helpers;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
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
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
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

            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPOST(ShoppingCartVM shoppingCartVM)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            ShoppingCartVM.Carts = _unitOfWork.ShoppingCart.GetAll(p => p.ApplicationUserId == userId, x => x.Product).ToList();

            ShoppingCartVM.OrderHeader.OrderTotal = ShoppingCartVM.OrderHeader.OrderTotal - ShoppingCartVM.OrderHeader.Discount;

            ShoppingCartVM.OrderHeader.OrderTime = DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

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

            //APIContext apiContext = PaypalGetAccessTokenHelper.GetAPIContext(_paypalSettings);

                var successUrl = Request.Host + $"/Customer/ShoppingCart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}";
                var cancelUrl = Request.Host + "Customer/ShoppingCart/Index";

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }

        public IActionResult Demo()
        {
            PaypalHelpers.RunPaypalDemo();
            return View();
        }

        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }

      

        #region Cart Options
        public IActionResult Remove(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            _unitOfWork.ShoppingCart.Remove(productInCart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            if (productInCart.Quantity <= 1)
            {
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
