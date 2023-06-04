using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.ViewModels.Customer;

namespace SellWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ShoppingCartVM ShoppingCartVM { get; set; } = new ShoppingCartVM();
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var listProduct = _unitOfWork.ShoppingCart.GetAll(p => p.ApplicationUserId == userId, x => x.Product).ToList();
            ShoppingCartVM = new()
            {
                Carts = listProduct,
                TotalPrice = listProduct.Sum(p => p.Product.Price)
            };
            return View(ShoppingCartVM);
        }
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
    }

}
