using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;

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
    }
}
