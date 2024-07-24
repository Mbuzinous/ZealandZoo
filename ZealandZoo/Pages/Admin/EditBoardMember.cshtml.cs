using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZoo.Pages.Administration
{
    [Authorize(Roles = "admin")]
    public class EditBoardMemberModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
