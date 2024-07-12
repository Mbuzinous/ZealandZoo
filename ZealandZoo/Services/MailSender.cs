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

        public bool ValidateEmailFormat(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
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