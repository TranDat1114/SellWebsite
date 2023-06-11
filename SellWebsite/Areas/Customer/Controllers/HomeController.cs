﻿using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using NuGet.Protocol;

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

        [Authorize]
        public IActionResult AddToCart(int productId)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == productId);

            if (cartFromDb != null)
            {
                //Logic nếu sản phẩm có rồi
                TempData["Success"] = "Product allready in your cart";
            }
            else
            {
                var cart = new ShoppingCart()
                {
                    Product = _unitOfWork.Product.Get(x => x.Id == productId, p => p.Categories!),
                    ProductId = productId,
                };
                cart.ApplicationUserId = userId;
                _unitOfWork.ShoppingCart.Add(cart);
                _unitOfWork.Save();
                TempData["Success"] = "Add product to cart successful";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string query)
        {
            // Perform the search based on the query
            var searchResults = _unitOfWork.Product.GetAll(p=>p.Title.Contains(query)).ToList();

            // Return the partial view with the search results
            return PartialView("_SearchResults", searchResults);
        }


    }
}