using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWebsite.Utility.IdentityHandler
{
    //Tạo các role ở đây -> tiện cho việc xử lý tạo vào so sánh phân quyền,...
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Employee = "Employee";
        public const string Role_Admin = "Admin";
        public const string Role_Boss = "Boss";
    }
}
