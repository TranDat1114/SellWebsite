﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory
{
    //Kế thừa biến db từ Reponsitory và kế thừa các phương thức từ interface ICategoryReponsitory
    public class ShoppingCartReponsitory : Reponsitory<ShoppingCart>, IShoppingCartReponsitory
    {
        //Như trên
        private ApplicationDbContext _db;
        //db nhận được dựa trên lớp kế thừa Reponsitory<Category>
        public ShoppingCartReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //Cập nhật dữ liệu cho bảng Categories
        public void Update(ShoppingCart shoppingCart)
        {
            _db.Update(shoppingCart);
        }
        //Lưu dữ liệu vào bảng Categories
        public void Save()
        {
            _db.SaveChanges();
        }


    }
}