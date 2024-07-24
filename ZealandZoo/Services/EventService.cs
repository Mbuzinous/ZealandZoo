using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZoo.Interfaces;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class EventService : IEventService
    {
        private readonly List<Event> _events;

        public EventService()
        {
            // Initialize with some dummy data
            _events = new List<Event>
            {
                new Event { Id = 1, Date = DateTime.Now.Date, Title = "Sample Event", Description = "This is a sample event." }
            };
        }

        public List<Event> GetEvents() => _events;

        public List<Event> GetEventsByDate(DateTime date) => _events.Where(e => e.Date.Date == date.Date).ToList();

        public Event GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public void AddEvent(Event newEvent)
        {
            newEvent.Id = _events.Max(e => e.Id) + 1;
            _events.Add(newEvent);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            var existingEvent = GetEventById(updatedEvent.Id);
            if (existingEvent != null)
            {
                existingEvent.Date = updatedEvent.Date;
                existingEvent.Title = updatedEvent.Title;
                existingEvent.Description = updatedEvent.Description;
            }
        }

        public void DeleteEvent(int id)
        {
            var eventToDelete = GetEventById(id);
            if (eventToDelete != null)
            {
                _events.Remove(eventToDelete);
            }
        }
    }
}
