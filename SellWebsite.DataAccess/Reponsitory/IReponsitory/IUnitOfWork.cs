using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.DataAccess.Data;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    public interface IUnitOfWork
    {
        ICategoryReponsitory Category { get; }
        IProductReponsitory Product { get; }
        void Save();
    }
}
