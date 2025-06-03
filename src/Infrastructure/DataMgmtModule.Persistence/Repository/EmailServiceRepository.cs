using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;

namespace DataMgmtModule.Persistence.Repository
{
    public class EmailServiceRepository : IEmailServiceRepository
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                // Basic SMTP example - adapt as needed
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("kapillund29@gmail.com", "yxxk xpsa htlk kxma"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("kapillund29@gmail.com", "DMM Support Team"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml,
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send email: " + ex.Message, ex);
            }
        }
    }
}
