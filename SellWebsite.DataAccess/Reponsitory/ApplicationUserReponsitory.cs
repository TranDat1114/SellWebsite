using System;
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
    public class ApplicationUserReponsitory : Reponsitory<ApplicationUser>, IApplicationUserReponsitory
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }
    }
}
