﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    //Interface Category kế thừa từ IReponsitory<T> được đặt kiểu dữ liệu là Category
    public interface ICategoryReponsitory : IReponsitory<Category>
    {
        //Cập nhật dữ liệu
        void Update(Category category);
        //Lưu dữ liệu vào database
        //Viết ở đây vì có thể tùy mỗi table sẽ có một cách xữ lý dữ liệu khác nhau
    }
}
