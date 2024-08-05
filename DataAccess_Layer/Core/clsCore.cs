using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.IdentityModel.Tokens;


namespace Core_Layer.Core
{
    public class clsCore
    {


        public class EmailSettings
        {
            public string SenderEmail { get; set; }
            public string MainEmailAppPass { get; set; }

            public EmailSettings(string SenderEmail, string MainEmailAppPass)
            {
                this.SenderEmail = SenderEmail;
                this.MainEmailAppPass = MainEmailAppPass;
            }
        }

        public static bool SendEmail(string ToMail, string Subject, string Body)
        {
            if (string.IsNullOrEmpty(ToMail))
                return false;

            // Read JSON file contents
            string json = File.ReadAllText("JSONs/jsonEmailSettings.json");

            // Deserialize JSON data into C# object
            EmailSettings EmailSettings = JsonSerializer.Deserialize<EmailSettings>(json);

            if (EmailSettings == null)
                return false;


            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailSettings.SenderEmail);
            message.Subject = Subject;
            message.To.Add(new MailAddress(ToMail));
            message.Body = Body;
            message.IsBodyHtml = true;


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(EmailSettings.SenderEmail, EmailSettings.MainEmailAppPass),
                EnableSsl = true,
            };

            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



    }
}
