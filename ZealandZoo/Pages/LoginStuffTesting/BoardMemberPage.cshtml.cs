using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZoo.Pages.LoginStuffTesting
{
    [Authorize(Roles = "board")]
    public class BoardMemberPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
