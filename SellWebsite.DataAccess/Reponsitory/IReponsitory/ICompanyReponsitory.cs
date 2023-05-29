﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    public interface ICompanyReponsitory : IReponsitory<Company>
    {
        void Update(Company company);
        void Save();
    }
}
