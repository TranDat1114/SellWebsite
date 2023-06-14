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
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration configuration)
        {
            _config = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            #region Tạm thời chưa triển khai gửi email
            //Triển khai gửi mail ở đây
            // Tạo đối tượng MailMessage
            var a = _config["Mail:SMTPHostName"];
            var mail = new MailMessage();
            mail.From = new MailAddress("postmaster@sandbox2cd0e25e52cd4685b7600fdb2f60e884.mailgun.org", "PhuDat");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = htmlMessage;

            // Cấu hình thông tin SMTP  
            SmtpClient smtpClient = new SmtpClient(_config["Mail:SMTPHostName"], Convert.ToInt32(_config["Mail:Port"]));
            //Ứng dụng thực tế
            //smtpClient.Credentials = new NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            //Môi trường sandbox
            smtpClient.Credentials = new NetworkCredential(_config["Mail:UsernameSandBox"], _config["Mail:PassSandBox"]);
            //smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;

            // Gửi email
            return smtpClient.SendMailAsync(mail);
            #endregion
            //return Task.CompletedTask;

        }
    }
}
