using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;


namespace SellWebsite.Utility.IdentityHandler
{
    public class EmailSender : IEmailSender
    {
        private readonly string key;
        public EmailSender(IConfiguration configuration)
        {
            key = configuration["Mail:Password"]!;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            #region Tạm thời chưa triển khai gửi email
            //Triển khai gửi mail ở đây
            // Tạo đối tượng MailMessage

            //var mail = new MailMessage();
            //mail.From = new MailAddress("jackandy249@gmail.com", "PhuDat");
            //mail.To.Add(email);
            //mail.Subject = subject;
            //mail.Body = htmlMessage;

            //// Cấu hình thông tin SMTP
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("jackandy@gmail.com", key);
            //smtpClient.EnableSsl = true;

            //// Gửi email
            //return smtpClient.SendMailAsync(mail);
            #endregion
            return Task.CompletedTask;

        }
    }
}
