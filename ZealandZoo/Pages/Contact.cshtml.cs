using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Pages
{
    public class ContactModel : PageModel
    {
        private IMailSender _mailSender;

        [BindProperty]
        public MailDto Mail { get; set; } = new MailDto();

        public ContactModel(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                Console.WriteLine("Messege did not send");

            }
            _mailSender.SendMail(Mail.FromEmailAddress, Mail.Subject, Mail.Message);
            return RedirectToPage("Index");
            Console.WriteLine("Messege sent");
        }
    }
}
