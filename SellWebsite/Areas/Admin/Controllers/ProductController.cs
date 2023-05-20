using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objProducts = _unitOfWork.Product.GetAll(p => p.Categories);

            return View(objProducts);
        }

        public IActionResult Create()
        {

            var productVM = new ProductVM()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new CategoryListVM()
                {
                    Id = u.Id,
                    Name = u.NameEnglish,
                }),
                Product = new Product(),
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.CategoryIdList != null)
                {
                    foreach (var item in productVM.CategoryIdList)
                    {
                        productVM.Product.Categories.Add(_unitOfWork.Category.GetAll().First(p => p.Id == item));
                    }
                }
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["Success"] = "Product created successfully";

                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryIdList = _unitOfWork.Product.Get(obj => obj.Id == id, p => p.Categories).Categories.Select(u => u.Id).ToList();

            var productVM = new ProductVM()
            {
                Product = _unitOfWork.Product.Get(obj => obj.Id == id),

                CategoryIdList = categoryIdList,
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new CategoryListVM()
                {
                    Id = u.Id,
                    Name = u.NameEnglish,
                    IsSelected = categoryIdList.Contains(u.Id)
                })
            };

            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Save();

                TempData["Success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productVM = new ProductVM()
            {
                Product = _unitOfWork.Product.Get(obj => obj.Id == id),
            };

            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var product = _unitOfWork.Product.Get(obj => obj.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
