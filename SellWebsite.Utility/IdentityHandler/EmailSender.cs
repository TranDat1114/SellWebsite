using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.UI.Services;

using MimeKit;

namespace SellWebsite.Utility.IdentityHandler
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            //Triển khai gửi mail ở đây
            //Tạm thời chưa triển khai gửi email


            // Cấu hình thông tin SMTP
            using (var smtp_client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jackandy@gmail.com", "cokngurcfknhghvz"),
                EnableSsl = true,
            })
            {

                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jackandy249@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                // Gửi email
                await smtp_client.SendMailAsync(mail);

            };
            return ;
        }
    }
}
