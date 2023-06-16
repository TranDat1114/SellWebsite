﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MailKit.Net.Smtp;

using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

using MimeKit;

using Org.BouncyCastle.Asn1.Crmf;

using RestSharp;
using RestSharp.Authenticators;

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
            ////Triển khai gửi mail ở đây
            //// Tạo đối tượng MailMessage
            //var mail = new MailMessage();
            //mail.From = new MailAddress(_config["Mail:UsernameSandBox"], "PhuDat");
            //mail.To.Add(email);
            //mail.Subject = subject;
            //mail.Body = htmlMessage;

            //// Cấu hình thông tin SMTP  
            //SmtpClient smtpClient = new SmtpClient(_config["Mail:SMTPHostName"], Convert.ToInt32(_config["Mail:Port"]));
            ////Ứng dụng thực tế
            //smtpClient.Credentials = new NetworkCredential(_config["Mail:Username"], _config["Mail:Password"]);
            ////Môi trường sandbox
            ////smtpClient.Credentials = new NetworkCredential(_config["Mail:UsernameSandBox"], _config["Mail:PassSandBox"]);
            ////smtpClient.UseDefaultCredentials = true;
            //smtpClient.EnableSsl = true;

            //// Gửi email
            //return smtpClient.SendMailAsync(mail);
            #endregion

            //var message = new MimeMessage();

            //message.From.Add(new MailboxAddress("Sender Name", _config["Mail:Username"]));
            //message.To.Add(new MailboxAddress("Receiver Name", email));

            //message.Subject = subject;
            //message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            //{
            //    Text = htmlMessage
            //};
            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect(_config["Mail:SMTPHostName"], Convert.ToInt32(_config["Mail:Port"]), false);

            //    // Note: only needed if the SMTP server requires authentication
            //    smtp.Authenticate(_config["Mail:Username"], _config["Mail:Password"]);

            //    smtp.Send(message);
            //    smtp.Disconnect(true);
            //}
            return Task.CompletedTask;

        }
    }
}
