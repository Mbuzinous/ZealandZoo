using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Pages.AboutUs
{
    public class BoardMembersModel : PageModel
    {
        private IBoardMemberRepository Repo { get; set; }

        public List<BoardMember> BoardMembers { get; private set; } = new List<BoardMember>();

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public BoardMembersModel(IBoardMemberRepository repository)
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
