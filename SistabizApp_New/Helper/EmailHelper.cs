using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class EmailHelper
    {
        public bool SendEmail(string userEmail, string confirmationLink)
        {

            MailMessage mail = new MailMessage();

            mail.To.Add("joshijitu9587@gmail.com");
            mail.From = new MailAddress("developer2514122@gmail.com");
            mail.Subject = "Confirmation of Registration on Job Junction.";
            string Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";
            mail.Body = confirmationLink;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("developer2514122@gmail.com", "xjz8XF4@10");
            smtp.Port = 587;
            //Or your Smtp Email ID and Password
            smtp.Send(mail);


            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("developer2514122@gmail.com");
            //mailMessage.To.Add(new MailAddress("joshijitu9587@gmail.com"));

            //mailMessage.Subject = "Confirm your email";
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = confirmationLink;

            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("developer2514122@gmail.com", "xjz8XF4@10");
            //client.Host = "smtp.gmail.com";
            //client.Port = 587;
            //client.UseDefaultCredentials = false;
            //client.EnableSsl = true;

            try
            {
                
            //    client.Send(mailMessage);
               return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
