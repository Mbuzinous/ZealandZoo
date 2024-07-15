using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Interface
{
    public interface IMailSender
    {
        void SendMail(string fromFirstName, string fromLastName, string fromEmailAddress, string subject, string body);

    }
}
