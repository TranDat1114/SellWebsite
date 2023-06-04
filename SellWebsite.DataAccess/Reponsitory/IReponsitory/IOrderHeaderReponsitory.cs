﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Reponsitory.IReponsitory
{
    public interface IOrderHeaderReponsitory : IReponsitory<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void Save();
    }
}
