using SportsBetting.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsBetting.Services.Contracts
{
    public interface IEventService
    {
        void AddEvent(Event sportEvent);
        void UpdateEvent(Event sportEvent);
        void DeleteEvent(Event sportEvent);
        IQueryable<Event> GetAllEvents();
    }
}
