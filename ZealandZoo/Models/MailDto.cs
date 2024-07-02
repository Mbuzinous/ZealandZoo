using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class MailDto
    {
        public string FromEmailAddress { get; set; }

        [Required, MaxLength(20)]
        public string Subject { get; set; }

        [Required, MaxLength(300)]
        public string Message { get; set; } 
    }
}
