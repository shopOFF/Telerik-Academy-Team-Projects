using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services.Contracts;
using System;

namespace SportsBetting.Services
{
    public class EventService : IEventService
    {
        private readonly IEfRepository<Event> eventRepo;
        private readonly IEfUnitOfWork uow;

        public EventService(IEfRepository<Event> eventRepo, IEfUnitOfWork uow)
        {
            if (eventRepo == null)
            {
                throw new ArgumentNullException("EventRepo can not be null!");
            }

            this.eventRepo = eventRepo;
            this.uow = uow;

        }

        public void AddEvent(Event sportEvent)
        {
            this.eventRepo.Add(sportEvent);

            uow.Commit();
        }
    }
}
