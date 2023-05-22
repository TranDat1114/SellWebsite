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

        //Hàm Create cũ đặt tên và chỉnh sửa lại, update và insert
        public IActionResult Upsert(int? id)
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
            if (id != null || id != 0)
            {
                productVM.Product = _unitOfWork.Product.Get(p => p.Id == id);
            }
            return View(productVM);


        }

        //Upsert là create và edit kết hợp
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                //Lệnh dưới để cập nhật categories cho product

                _unitOfWork.Product.UpdateCategories(productVM.Product, productVM.CategoryIdList);
                _unitOfWork.Save();
                TempData["Success"] = "Product created successfully";

                return RedirectToAction("Index");
            }
            return View();

        }

       
        //[HttpPost]
        //public IActionResult Edit(ProductVM productVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(productVM.Product);
        //        //Lệnh dưới để cập nhật categories cho product
        //        _unitOfWork.Product.UpdateCategories(productVM.Product, productVM.CategoryIdList);
        //        _unitOfWork.Save();

        //        TempData["Success"] = "Product updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        public IActionResult Delete(int? id)
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
