using System.Text.Json.Serialization;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using Microsoft.AspNetCore.Hosting;
using SellWebsite.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using SellWebsite.Utility.IdentityHandler;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Boss},{SD.Role_Employee}")]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShoppingCartController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var shoppingCart = new ShoppingCart();
            if (id == null || id == 0)
            {
                return View(shoppingCart);
            }
            else
            {
                shoppingCart = _unitOfWork.ShoppingCart.Get(p => p.CartId == id);
            }
            return View(shoppingCart);
        }

        [HttpPost]
        public IActionResult Upsert(ShoppingCart shoppingCart)
        {

            if (ModelState.IsValid)
            {

                if (shoppingCart.CartId == 0)
                {
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
                }
                else
                {
                    _unitOfWork.ShoppingCart.Update(shoppingCart);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Shopping Cart update successfully";

                return RedirectToAction("Index");
            }
            return View(shoppingCart);

        }

        #region API Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll().ToList();
            return Json(new { data = shoppingCarts });
        }

        //[Route("/admin/product/delete/{id:int?}")]
        public IActionResult Delete(int? id)
        {
            var shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.CartId == id);

            if (shoppingCart == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
          
            _unitOfWork.ShoppingCart.Remove(shoppingCart!);

            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
