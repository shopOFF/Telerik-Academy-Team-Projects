using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsBetting.Services
{
    public class EventService : IEventService
    {
        private readonly IEfRepository<Event> eventRepo;
        private readonly IEfUnitOfWork uow;

        public EventService(IEfRepository<Event> eventRepo, IEfUnitOfWork uow)
        {
            if (eventRepo == null || uow == null)
            {
                throw new ArgumentNullException("EventService initializing parameters can not be null!");
            }

            this.eventRepo = eventRepo;
            this.uow = uow;
        }

        public void AddEvent(Event sportEvent)
        {
            this.eventRepo.Add(sportEvent);

            uow.Commit();
        }

        public void DeleteEvent(Event sportEvent)
        {
            this.eventRepo.Delete(sportEvent);

            uow.Commit();
        }

        public IQueryable<Event> GetAllEvents()
        {
            return this.eventRepo.GetAll;
        }

        public void UpdateEvent(Event sportEvent)
        {
            this.eventRepo.Update(sportEvent);

            uow.Commit();
        }
    }
}
