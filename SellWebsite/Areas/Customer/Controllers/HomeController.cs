using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;
using SellWebsite.Models.ViewModels.Customer;

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
            var homeVM = new HomeVM()
            {
                Products = _unitOfWork.Product.GetAll(includes: p => p.Categories!).ToList(),
                Categories = _unitOfWork.Category.GetAll().ToList(),
            };
            return View(homeVM);
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
        [HttpPost]
        [Authorize]
        public IActionResult Detail(ShoppingCart shoppingCart)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);
            if (cartFromDb != null)
            {

            }
            else
            {
            shoppingCart.ApplicationUserId = userId;
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            }
            //return RedirectToAction("Index");
            //Sử dụng ở dưới tránh viết sai chính tả và *MagicString*
            return RedirectToAction(nameof(ShoppingCartController.Index), nameof(ShoppingCartController).Replace("Controller", ""));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}