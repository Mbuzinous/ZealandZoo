using Microsoft.AspNetCore.Identity;

namespace ZealandZoo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
    }
}
