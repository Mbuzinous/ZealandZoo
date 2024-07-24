using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using ZealandZoo.Interface;
using ZealandZoo.Models;
using ZealandZoo.Pages.AboutUs;

namespace ZealandZoo.Pages.Administration
{
    [Authorize(Roles = "admin")]
    public class BoardMemberOverviewModel : PageModel
    {
        private IBoardMemberRepository Repo { get; set; }

        public List<BoardMember> BoardMembers { get; private set; } = new List<BoardMember>();

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public BoardMemberOverviewModel(IBoardMemberRepository repository) 
        {
            Repo = repository;
        }

        public IActionResult OnGet()
        {
            BoardMembers = Repo.GetAlBoardMembers();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                if (Convert.ToInt32(FilterCriteria) > 0)
                {
                    BoardMembers = Repo.FilterBoardMembersBySemester(Convert.ToInt32(FilterCriteria));
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}
