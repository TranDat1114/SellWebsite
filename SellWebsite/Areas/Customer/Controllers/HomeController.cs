using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using NuGet.Protocol;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;
using SellWebsite.Models.ViewModels.Customer;
using SellWebsite.Utility;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //Cộng dữ liệu đã thêm vào cart vào tài khoản người dùng sau khi đăng nhập
            var homeVM = new HomeVM()
            {
                Products = _unitOfWork.Product.GetAll(includes: p => p.Categories!).ToList(),
                Categories = _unitOfWork.Category.GetAll().ToList(),
            };

            return View(homeVM);
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Json(new { data = _unitOfWork.Category.GetAll().Select(p => p.NameEnglish).ToList() });
        }

        public IActionResult Detail(int id)
        {
            var cart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(x => x.Id == id, p => p.Categories!),
                ProductId = id,
            };
            return View(cart);
        }

        #region Chỉnh sửa
        //[HttpPost]
        //[Authorize]
        //public IActionResult Detail(ShoppingCart shoppingCart)
        //{
        //    var claimIdentity = (ClaimsIdentity)User.Identity!;
        //    var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        //    var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);
        //    if (cartFromDb != null)
        //    {
        //        TempData["Success"] = "Product allready in your cart";

        //    }
        //    else
        //    {
        //        shoppingCart.ApplicationUserId = userId;
        //        _unitOfWork.ShoppingCart.Add(shoppingCart);

        //        _unitOfWork.Save();

        //        HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

        //        TempData["Success"] = "Add product to cart successful";
        //    }
        //    //return RedirectToAction("Index");
        //    //Sử dụng ở dưới tránh viết sai chính tả và *MagicString*
        //    return RedirectToAction(nameof(ShoppingCartController.Index), nameof(ShoppingCartController).Replace("Controller", ""));
        //}
        #endregion

        public IActionResult AddToCart(int productId)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;

            var ShopCartString = HttpContext.Session.GetString(SD.SessionShopingCarts);

            var shoppingCarts = new List<ShoppingCart>();

            if (!string.IsNullOrEmpty(ShopCartString))
            {
                shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(ShopCartString);
            }

            if (claimIdentity.Name != null)
            {
                var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                shoppingCarts = _unitOfWork.ShoppingCart.GetAll().ToList();

                var cart = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == productId);

                if (cart != null)
                {
                    //Logic nếu sản phẩm có rồi
                    cart.Quantity += 1;
                    _unitOfWork.ShoppingCart.Update(cart);
                    _unitOfWork.Save();

                    shoppingCarts.FirstOrDefault(p => p.CartId == cart.CartId)!.Quantity += 1;

                    //Sau kiểm tra sản phẩm có phải trang web hay không
                    //Nếu không thì cộng 
                    TempData["Success"] = "Product allready in your cart";
                }
                else
                {
                    cart = new ShoppingCart
                    {
                        Product = _unitOfWork.Product.Get(x => x.Id == productId, p => p.Categories!),
                        ProductId = productId,
                        ApplicationUserId = userId
                    };
                    _unitOfWork.ShoppingCart.Add(cart);
                    _unitOfWork.Save();

                    shoppingCarts.Add(cart);

                    TempData["Success"] = "Add product to cart successful";
                }
            }
            else
            {
                if (shoppingCarts?.FirstOrDefault(p => p.ApplicationUserId == "0" && p.ProductId == productId) != null)
                {
                    shoppingCarts.FirstOrDefault(p => p.ApplicationUserId == "0" && p.ProductId == productId)!.Quantity += 1;

                    TempData["Success"] = "Product allready in your cart";
                }
                else
                {
                    var cart = new ShoppingCart()
                    {
                        Product = _unitOfWork.Product.Get(x => x.Id == productId, p => p.Categories!),
                        ProductId = productId,
                        ApplicationUserId = "0",
                        Quantity = 1,
                    };
                    shoppingCarts?.Add(cart);
                }

                TempData["Success"] = "Add product to cart successful";
            }

            HttpContext.Session.SetString(SD.SessionShopingCarts, JsonConvert.SerializeObject(shoppingCarts, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Search(string query)
        {
            // Perform the search based on the query
            var searchResults = _unitOfWork.Product.GetAll(p => p.Title.Contains(query)).Take(5).ToList();

            // Return the partial view with the search results
            return PartialView("_SearchResults", searchResults);
        }


    }
}