using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;
using SellWebsite.Models.ViewModels;

namespace SellWebsite.DataAccess.Reponsitory
{
    public class ProductReponsitory : Reponsitory<Product>, IProductReponsitory
    {
        //Như trên
        private ApplicationDbContext _db;
        //db nhận được dựa trên lớp kế thừa Reponsitory<Category>
        public ProductReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //Cập nhật dữ liệu cho bảng Categories
        public void Update(Product product)
        {
            _db.Update(product);
        }
        //Lưu dữ liệu vào bảng Categories
        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateCategories(Product product, List<int> selectedCategoryIds)
        {
            //Cập nhật dữ liệu cho bảng Categories
            if (product.Id != 0)
            {
                product = Get(p => p.Id == product.Id, includes: p => p.Categories! );
            }

            // Xóa các danh mục hiện tại của sản phẩm

            if (product.Categories != null)
            {
                product.Categories.Clear();
            }
            else
            {
                product.Categories = new List<Category>();
            }

            if (selectedCategoryIds != null)
            {
                // Thêm các danh mục mới được chọn
                foreach (var categoryId in selectedCategoryIds)
                {
                    product.Categories.Add(_db.Categories.First(p => p.Id == categoryId));
                }
            }

        }
    }

}
