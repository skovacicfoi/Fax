using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Application.Services
{
    public class MessageUserServiceGmail : IMessageUserService
    {
        private readonly string SenderUsername = "sljunac3@gmail.com";
        private static string SenderPassword = "Monster123";
        public string Recipient { get; set; }
        public bool SendMessage(string message, string subject, string recipient)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(SenderUsername);
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SenderUsername, SenderPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
