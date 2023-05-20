using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    //Tạo một Interface IReponsitory có kiểu dữ liệu chuyển đổi để có thể sử dụng lại code 
    //Thế giới bên kia người ta toàn làm vậy, nên mình nghe và làm theo Hề hề :3
    public interface IReponsitory<T> where T : class
    {
        //Phương thức để lấy toàn bộ dữ liệu
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        //Phương thức để lấy 1-record thông qua filter
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        //Thêm 1-record vào database
        void Add(T item);
        //Xóa 1 record trong database
        void Remove(T item);
        //Xóa nhièu record trong datavase
        void RemoveRange(IEnumerable<T> items);
    }
}
