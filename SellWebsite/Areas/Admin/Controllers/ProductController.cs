using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using NuGet.ContentModel;

using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels.Admin;
using SellWebsite.Utility.IdentityHandler;

namespace SellWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_Boss},{SD.Role_Employee}")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //Sử dụng API nên không cần dùng đoạn dưới nữa
            //var objProducts = _unitOfWork.Product.GetAll(includes: p => p.Categories!).ToList();
            //return View(objProducts);

            return View();
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
                    IsSelected = false,
                }).ToList(),
                Product = new Product(),
            };
            if (id == null || id == 0)
            {

            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(p => p.Id == id, p => p.Categories!);
                if (productVM.Product.Categories != null)
                {
                    foreach (var item in productVM.Product.Categories)
                    {
                        productVM.CategoryList.First(p => p.Id == item.Id).IsSelected = true;
                    }
                }
            }
            return View(productVM);

        }

        //Upsert là create và edit kết hợp
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string folderName = "products";
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @$"assets\Images\{folderName}\");

                    if (!string.IsNullOrEmpty(productVM.Product.Image))
                    {
                        //Xóa img cũ đi 
                        var oldIMGPath = Path.Combine(wwwRootPath, productVM.Product.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldIMGPath))
                        {
                            System.IO.File.Delete(oldIMGPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.Image = @$"\assets\Images\{folderName}\{fileName}";
                }

                if (productVM.Product.Id == 0)
                {
                    productVM.Product.CreatedDate = DateTime.Now;
                    productVM.Product.UpdatedDate = DateTime.Now;
                    _unitOfWork.Product.Add(productVM.Product);

                }
                else
                {
                    productVM.Product.UpdatedDate = DateTime.Now;
                    _unitOfWork.Product.Update(productVM.Product);
                }
                //Lệnh dưới để cập nhật categories cho product

                _unitOfWork.Product.UpdateCategories(productVM.Product, productVM.CategoryIdList);
                _unitOfWork.Save();
                TempData["Success"] = "Product update successfully";

                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new CategoryListVM()
                {
                    Id = u.Id,
                    Name = u.NameEnglish,
                    IsSelected = productVM.CategoryIdList.Contains(u.Id),
                }).ToList();
            }

            return View(productVM);
        }

        //Sài API cho nó tiện API ở dưới
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var categoryIdList = _unitOfWork.Product.Get(obj => obj.Id == id, p => p.Categories).Categories.Select(u => u.Id).ToList();
        //    var productVM = new ProductVM()
        //    {
        //        Product = _unitOfWork.Product.Get(obj => obj.Id == id),

        //        CategoryIdList = categoryIdList,
        //        CategoryList = _unitOfWork.Category.GetAll().Select(u => new CategoryListVM()
        //        {
        //            Id = u.Id,
        //            Name = u.NameEnglish,
        //            IsSelected = categoryIdList.Contains(u.Id)
        //        }).ToList()
        //    };

        //    if (productVM.Product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productVM);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    var product = _unitOfWork.Product.Get(obj => obj.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Product.Remove(product);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Product deleted successfully";
        //    return RedirectToAction("Index");
        //}


        #region API Call

        [HttpGet]
        public IActionResult GetAll()
        {
            //Cơ bản là select xong cái thằng nào mà bị null thì ajax table api nó không hiểu nên mình cho nó thành list rổng thay vì null
            List<Product> products = _unitOfWork.Product
                .GetAll(includes: p => p.Categories!).ToList()
                .Select(p =>
                        {
                            p.Categories ??= new List<Category>() { new() { DescriptionEnglish = "" } };
                            return p;
                        }
            ).ToList();
            //ReferenceHandler.Preserve hỗ trợ việc tránh liên kết vòng  khi tạo json
            return Json(new { data = products }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
        }

        //[Route("/admin/product/delete/{id:int?}")]
        public IActionResult Delete(int? id)
        {
            var product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldIMG = Path.Combine(_webHostEnvironment.WebRootPath, product?.Image?.Trim('\\')!);
            if (System.IO.File.Exists(oldIMG))
            {
                System.IO.File.Delete(oldIMG);
            }

            _unitOfWork.Product.Remove(product!);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
