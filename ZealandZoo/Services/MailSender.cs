using ZealandZoo.Interface;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using System.Globalization;
using System.Text.RegularExpressions;
using NuGet.Packaging.Signing;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;


namespace ZealandZoo.Services
{
    public class MailSender : IMailSender
    {
        public MailSender()
        {
        }

        public void SendMail(string firstName, string lastName, string emailAddress, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Zealand Zoo - Tak, vi har modtaget din besked", "zealandzookontakt@gmail.com"));
            message.To.Add(MailboxAddress.Parse(emailAddress));
            message.Cc.Add(MailboxAddress.Parse("zealandzoo10@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = $"Fra {firstName} {lastName}"
                + "<br />"
                + $"E-mailadresse: {emailAddress}"
                + "<br />"
                + "<br />"
                + body
            };

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.Auto);
            client.Authenticate("zealandzookontakt@gmail.com", "mjuqpcyzzcawobla");
            client.Send(message);

            client.Disconnect(true);
            client.Dispose();

        }


    }
}