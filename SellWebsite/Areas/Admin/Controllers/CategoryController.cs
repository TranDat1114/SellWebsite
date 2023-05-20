using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objCategories = _unitOfWork.Category.GetAll();
            return View(objCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            //Custom Validation testing
            //if (category.NameEnglish != null && category.NameEnglish.ToLower() == "test")
            //{
            //    ModelState.AddModelError("Name", "Test is invalid value");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(categoryVM.Category);
                _unitOfWork.Save();
                TempData["Success"] = "Category created successfully";

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

            var categoryVM = new CategoryVM()
            {
                Category = _unitOfWork.Category.Get(obj => obj.Id == id),
            };

            if (categoryVM.Category == null)
            {
                return NotFound();
            }
            return View(categoryVM);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                //Phải có ID không thì bị lỗi new 
                _unitOfWork.Category.Update(categoryVM.Category);
                _unitOfWork.Save();

                TempData["Success"] = "Category updated successfully";
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
            var categoryVM = new CategoryVM()
            {
                Category = _unitOfWork.Category.Get(obj => obj.Id == id),
            };
            if (categoryVM.Category == null)
            {
                return NotFound();
            }
            return View(categoryVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var category = _unitOfWork.Category.Get(obj => obj.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
