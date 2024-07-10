using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Interface
{
    public interface IMailSender
    {
        bool ValidateEmailFormat(string email);

        void SendMail(string fromFirstName, string fromLastName, string fromEmailAddress, string subject, string body);

    }
}
