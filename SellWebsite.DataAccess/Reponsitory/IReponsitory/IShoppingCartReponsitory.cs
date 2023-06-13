using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    //Interface Category kế thừa từ IReponsitory<T> được đặt kiểu dữ liệu là Category
    public interface IShoppingCartReponsitory : IReponsitory<ShoppingCart>
    {
        //Cập nhật dữ liệu
        void Update(ShoppingCart shoppingCart);
    }
}
