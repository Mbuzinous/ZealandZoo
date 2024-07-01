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
            message.From.Add(new MailboxAddress("Jakayla Lowe", "jakayla.lowe41@ethereal.email"));
            message.To.Add(MailboxAddress.Parse("zealandzoo10@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "From" + " " + fromEmailAddress
                + "<br />"
                + "<br />"
                + body
            };


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            client.Authenticate("jakayla.lowe41@ethereal.email", "RYyT2y15Ygw2xb9DWV");
            client.Send(message);

            client.Disconnect(true);
            client.Dispose();
        }
    }
}