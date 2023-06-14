using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Customer;
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

            var sessionShopCart = HttpContext.Session.GetString(SD.SessionShopingCarts);
            var shoppingCarts = new List<ShoppingCart>();
            if (sessionShopCart != null)
            {
                shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString(SD.SessionShopingCarts));
            }
            var cartQuantity = shoppingCarts.Count();
            if (claimIdentity.Name != null)
            {
                var listCart = _unitOfWork.ShoppingCart.GetAll().ToList();
                foreach (var item in listCart)
                {
                    if (!shoppingCarts.Any(p => p.ProductId == item.ProductId))
                    {
                        cartQuantity += 1;
                    }

                }
            }

            HttpContext.Session.SetInt32(SD.SessionCart, cartQuantity);

            return View(HttpContext.Session.GetInt32(SD.SessionCart));
        }
    }
}
