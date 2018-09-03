using SportsBetting.Data.Models;

namespace SportsBetting.Services.Contracts
{
    public interface IEventService
    {
        void AddEvent(Event sportEvent);
    }
}
