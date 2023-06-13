using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Utility;

namespace SellWebsite.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
                }

            }
            else
            {
                var sessionShopCart = HttpContext.Session.GetString(SD.SessionShopingCarts);
                var quantityOfProductInCart = 0;
                if (sessionShopCart != null)
                {
                    var shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString(SD.SessionShopingCarts));
                    quantityOfProductInCart = shoppingCarts.Count();
                }
                HttpContext.Session.SetInt32(SD.SessionCart, quantityOfProductInCart);
            }
            return View(HttpContext.Session.GetInt32(SD.SessionCart));
        }
    }
}
