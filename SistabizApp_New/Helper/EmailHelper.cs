using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class EmailHelper
    {
        public bool SendEmail(string userEmail, string confirmationLink)
        {

            MailMessage mail = new MailMessage();

            mail.To.Add(userEmail);
            mail.From = new MailAddress("jitendra.eglaf@gmail.com");
            mail.Subject = "Upgrade Breakthrough User.";
           // string Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";
            mail.Body = confirmationLink;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("jitendra.eglaf@gmail.com", "Jitendra@123");
            smtp.Port = 587;
            //Or your Smtp Email ID and Password
            smtp.Send(mail);


           

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

        public static bool SendResources(SendFileModel model)
        {
            string BaseUrl = string.Empty;
            if (model.Type == 2)
            {
                BaseUrl = Constant.Group;
            }
            else
            {
                BaseUrl = Constant.DigitalLibrary;
            }
            var filename = model.FileName;
            MailMessage mail = new MailMessage();

            mail.BodyEncoding = Encoding.UTF8;
            mail.Subject = "Resources";
            mail.Body = "File Name:-" + model.FileName;

            Attachment at = new Attachment(Path.Combine(Directory.GetCurrentDirectory(), BaseUrl, filename));
            mail.Attachments.Add(at);
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;

            mail.To.Add(model.Email);
            mail.From = new MailAddress("jitendra.eglaf@gmail.com");

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("jitendra.eglaf@gmail.com", "Jitendra@123");
            smtp.Port = 587;
            //Or your Smtp Email ID and Password
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
    }
}





