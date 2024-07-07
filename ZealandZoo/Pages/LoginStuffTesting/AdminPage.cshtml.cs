using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZoo.Pages.LoginStuffTesting
{
    [Authorize(Roles = "admin")]
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
