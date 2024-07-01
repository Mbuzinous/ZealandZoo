using Microsoft.AspNetCore.Identity;
using ZealandZoo.Interface;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ZealandZoo.Services
{
    public class MailSender : IMailSender
    {
        public MailSender()
        {
        }

        public void SendMail(string fromEmailAddress, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("KONTAKT ZEALAND ZOO", "zealandzoo10@gmail.com"));
            message.To.Add(MailboxAddress.Parse("zealandzookontakt@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "From" + " " + fromEmailAddress
                + "<br />"
                + "<br />"
                + body
            };


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465 , SecureSocketOptions.Auto);
            client.Authenticate("zealandzoo10@gmail.com", "yxzwyyczopqisefo");
            client.Send(message);

            client.Disconnect(true);
            client.Dispose();
        }
    }
}