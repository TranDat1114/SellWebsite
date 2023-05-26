using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.UI.Services;

namespace SellWebsite.Utility.IdentityHandler
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Triển khai gửi mail ở đây
            //Tạm thời chưa triển khai gửi email
            return Task.CompletedTask;
        }
    }
}
