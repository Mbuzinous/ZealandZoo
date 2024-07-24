using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZoo.Pages.Administration
{
    [Authorize(Roles = "admin")]
    public class DeleteBoardMemberModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
