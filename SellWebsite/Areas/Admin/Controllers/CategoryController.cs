using System.Text.Json.Serialization;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using Microsoft.AspNetCore.Hosting;
using SellWebsite.Models.ViewModels.Admin;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var objCategories = _unitOfWork.Category.GetAll();
            return View(objCategories);
        }

        public IActionResult Upsert(int? id)
        {
            var categoryVM = new CategoryVM()
            {
                Category = new Category(),
            };
            if (id == null || id == 0)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = _unitOfWork.Category.Get(p => p.Id == id);
            }
            return View(categoryVM);
        }

        [HttpPost]
        public IActionResult Upsert(CategoryVM categoryVM, IFormFile? file)
        {
            //Custom Validation testing
            //if (category.NameEnglish != null && category.NameEnglish.ToLower() == "test")
            //{
            //    ModelState.AddModelError("Name", "Test is invalid value");
            //}

            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string folderName = "categories";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @$"assets\Images\{folderName}\");

                    if (!string.IsNullOrEmpty(categoryVM.Category.Image))
                    {
                        //Xóa img cũ đi 
                        var oldIMGPath = Path.Combine(wwwRootPath, categoryVM.Category.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldIMGPath))
                        {
                            System.IO.File.Delete(oldIMGPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    categoryVM.Category.Image = @$"\assets\Images\{folderName}\{fileName}";
                }

                if (categoryVM.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(categoryVM.Category);
                }
                else
                {
                    _unitOfWork.Category.Update(categoryVM.Category);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Category update successfully";

                return RedirectToAction("Index");
            }
            return View(categoryVM);

        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var categoryVM = new CategoryVM()
        //    {
        //        Category = _unitOfWork.Category.Get(obj => obj.Id == id),
        //    };
        //    if (categoryVM.Category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoryVM);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    var category = _unitOfWork.Category.Get(obj => obj.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Category.Remove(category);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Category deleted successfully";
        //    return RedirectToAction("Index");
        //}

        #region API Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = categories });
        }

        //[Route("/admin/product/delete/{id:int?}")]
        public IActionResult Delete(int? id)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == id);

            if (category == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldIMG = Path.Combine(_webHostEnvironment.WebRootPath, category?.Image?.Trim('\\')!);
            if (System.IO.File.Exists(oldIMG))
            {
                System.IO.File.Delete(oldIMG);
            }

            _unitOfWork.Category.Remove(category!);


            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
