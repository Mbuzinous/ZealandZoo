namespace ZealandZoo.Interface
{
    public interface IMailSender
    {
        void SendMail(string fromEmailAddress, string subject, string body);
    }
}
