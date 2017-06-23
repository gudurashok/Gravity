using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Scalable.Shared.Common
{
    public static class Emailer
    {
        public static void SendMail(EmailMessage eMailMessage)
        {
            var fromAddress = new MailAddress(eMailMessage.FromAddress, eMailMessage.FromAddressDisplayName);
            const string fromPassword = "gw2ksoft";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 200000
            };

            //var rtfMail = AlternateView.CreateAlternateViewFromString(rtbBody.Rtf, null, "text/html");
            var toAddress = new MailAddress(eMailMessage.ToAddress, eMailMessage.ToAddressDisplayName);
            using (var message =
                new MailMessage(fromAddress, toAddress)
                {
                    Subject = eMailMessage.Subject,
                    Body = eMailMessage.Body
                })
            {
                //message.AlternateViews.Add(rtfMail);
                smtp.Send(message);
            }
        }
    }
}
