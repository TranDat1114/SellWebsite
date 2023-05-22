using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    public interface IProductReponsitory: IReponsitory<Product>
    {
        //Interface Category kế thừa từ IReponsitory<T> được đặt kiểu dữ liệu là Category

        //Cập nhật dữ liệu
        void Update(Product product);
        void UpdateCategories(Product product, List<int> selectedCategoryIds);
        //Lưu dữ liệu vào database
        //Viết ở đây vì có thể tùy mỗi table sẽ có một cách xữ lý dữ liệu khác nhau
        void Save();

    }
}
