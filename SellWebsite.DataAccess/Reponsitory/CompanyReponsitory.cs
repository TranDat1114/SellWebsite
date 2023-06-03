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
    public class CompanyReponsitory : Reponsitory<Company>, ICompanyReponsitory
    {
        private ApplicationDbContext _db;
        public CompanyReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
