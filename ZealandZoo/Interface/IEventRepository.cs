using ZealandZoo.Models;

namespace ZealandZoo.Interface
{
    public interface IEventRepository
    {
        //Create
        void CreateEvent(Event eventDto);

        //Read
        List<Event> GetAllEvents();
        Event FindEvent(int? id);

        //Update
        void UpdateEvent(Event eventDto);

        //Delete
        void DeleteEvent(int eventID);
    }
}
