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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryReponsitory Category { get; private set; }
        public IProductReponsitory Product { get; private set; }
        public ICompanyReponsitory Company { get; private set; }
        public IShoppingCartReponsitory ShoppingCart { get; private set; }
        public IApplicationUserReponsitory ApplicationUser { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryReponsitory(_db);
            Product = new ProductReponsitory(_db);
            Company = new CompanyReponsitory(_db);
            ShoppingCart = new ShoppingCartReponsitory(_db);
            ApplicationUser = new ApplicationUserReponsitory(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
