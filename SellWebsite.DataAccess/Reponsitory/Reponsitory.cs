using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;

namespace SellWebsite.DataAccess.Reponsitory
{
    //Class này dùng như class mồi để đỡ phải viết lại các phương thức... tại làm biếng
    //Nhưng mà thấy người ta cũng hay làm vầy :3 chắc hem có sao
    public class Reponsitory<T> : IReponsitory<T> where T : class
    {
        //Tạo một biến db để sử dụng trong Reponsitory
        private ApplicationDbContext _db;
        //Tạo một dbSet cho table trong database
        internal DbSet<T> dbSet;
        //Constructor Reponsitory lấy db từ ApplicationDbContext gán vào _db để sử dụng
        public Reponsitory(ApplicationDbContext db)
        {
            _db = db;
            //dbSet tượng trưng cho 1 table 
            this.dbSet = _db.Set<T>();
            //_db.Category == dbset
        }

        public void Add(T item)
        {
            //Thêm record vào bảng
            dbSet.Add(item);
        }

        //Truy vấn theo filter
        public T Get(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            //Làm biếng viết cho gọn đỡ phải tạo thêm 1 biến chứa dữ liệu trả về nhưng code vẫn tường minh phải hem? :3
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Bản nâng cấp để có thể include thêm các bảng liên quan
            if (query != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query?.FirstOrDefault()!;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            //Lấy hết nguyên dữ liệu của bảng và ToList()
            //Tương tự với _db.Categories.ToList();
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Bản nâng cấp để có thể include thêm các bảng liên quan
            if (query != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query!;
        }

        public void Remove(T item)
        {
            //Dễ hiểu nhưng chưa SaveChanges vì có thể còn xử lý thêm tùy từng bảng
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            //Chưa SaveChanges vì tương tự như trên
            dbSet.RemoveRange(items);

        }
    }
}
