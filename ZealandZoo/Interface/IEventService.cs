using System;
using System.Collections.Generic;
using ZealandZoo.Models;

namespace ZealandZoo.Interfaces
{
    public interface IEventService
    {
        List<Event> GetEvents();
        List<Event> GetEventsByDate(DateTime date);
        Event GetEventById(int id);
        void AddEvent(Event newEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(int id);
    }
}
