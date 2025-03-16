using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using Microsoft.Extensions.Options;

namespace MyProfile.Models
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;

        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public bool SendEmail(MailRequest mailRequest)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            email.To.Add(new MailAddress(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = mailRequest.Body;

            SmtpClient smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
            smtp.UseDefaultCredentials = false;

            NetworkCredential nc = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.Credentials = nc;

            smtp.EnableSsl = true;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            email.BodyEncoding = Encoding.UTF8;
            // mR.Attachments ==> attachmentsPath
            if (mailRequest.Attachments != null)
            {
                Attachment attachment = new Attachment(mailRequest.Attachments);
                email.Attachments.Add(attachment);
            }


            bool checkSend = true;
            
            smtp.SendAsync(email, _mailSettings.DisplayName);
            
            


            return checkSend;
        }
    }
}
