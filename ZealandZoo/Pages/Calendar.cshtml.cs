using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Pages
{
    public class CalendarModel : PageModel
    {
        private IEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public List<Event> EventList { get; private set; } = new List<Event>();


        public CalendarModel(IEventRepository repository)
        {
            repo = repository;
        }

        public void OnGet()
        {
            EventList = repo.GetAllEvents();
        }

        public IActionResult OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.CreateEvent(Event);
            return Redirect("/Calendar");
        }

        public IActionResult OnPostDelete(int id)
        {
            // Validate ID
            if (id == null)
            {
                return Page();
            }

            repo.DeleteEvent(id);
            return Redirect("/Calendar");
        }
    }
}