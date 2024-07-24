using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Interfaces;
using ZealandZoo.Models;
using System;
using System.Collections.Generic;

namespace ZealandZoo.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly IEventService _eventService;


        public CalendarModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        public List<Event> Events { get; set; }

        [BindProperty]
        public Event Event { get; set; }

        public void OnGet()
        {
            Events = _eventService.GetEvents();
        }

        public JsonResult OnGetEventsByDate(DateTime date)
        {
            var events = _eventService.GetEventsByDate(date);
            return new JsonResult(events);
        }

        public IActionResult OnPostAddEvent(Event newEvent)
        {
            _eventService.AddEvent(newEvent);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateEvent(Event updatedEvent)
        {
            _eventService.UpdateEvent(updatedEvent);
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteEvent(int id)
        {
            _eventService.DeleteEvent(id);
            return RedirectToPage();
        }
    }
}