using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Pages.Administration
{
    [Authorize(Roles = "admin")]
    public class CreateBoardMemberModel : PageModel
    {
        private IBoardMemberRepository Repo { get; set; }
        [BindProperty]
        public BoardMemberDto BoardMemberDto { get; set; } = new BoardMemberDto();

        public string ErrorMessage { get; private set; } = "";

        public string SuccessMessage { get; private set; } = "";

        public CreateBoardMemberModel(IBoardMemberRepository repository)
        {
            Repo = repository;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //Validate Input
            if (BoardMemberDto.ImageFile == null)
            {
                ModelState.AddModelError("ExhibitionDto.PhotoFile", "Du er nødt til at uploade et billed");
            }

            else if (BoardMemberDto.ImageFile == null)
            {
                ModelState.AddModelError("ExhibitionDto.AudioFile", "Du er nødt til at uploade mp3 lydfil");
            }

            else if (!ModelState.IsValid)
            {
                ErrorMessage = "Udfyld venligst alle ledige felter";
                return;
            }
            else
            {
                Repo.CreateBoardMember(BoardMemberDto);

                Repo.ClearBoardMemberDto(BoardMemberDto);

                ModelState.Clear();

                SuccessMessage = "Medlem er nu oprettet";

                Response.Redirect("/Admin/BoardMemberOverview");
            }
        }
    }
}
