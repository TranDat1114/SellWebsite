using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
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

        public IActionResult Remove(int id)
        {
            var productInCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            _unitOfWork.ShoppingCart.Remove(productInCart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        #region needFix
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
