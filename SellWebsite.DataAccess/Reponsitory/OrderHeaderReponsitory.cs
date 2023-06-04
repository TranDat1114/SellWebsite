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
    public class OrderHeaderReponsitory : Reponsitory<OrderHeader>, IOrderHeaderReponsitory
    {
        private ApplicationDbContext _db;
        public OrderHeaderReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeaders.Update(orderHeader);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(p => p.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(orderFromDb.PaymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdatePaypalPaymentId(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(p => p.Id == id);
            if (orderFromDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderFromDb.SessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderFromDb.PaymentIntendId = paymentIntentId;
                }
            }
        }
    }
}
