using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsBetting.Data;
using SportsBetting.Data.Common;
using SportsBetting.Data.Common.Contracts;
using SportsBetting.Data.Models;
using SportsBetting.Services.Contracts;

namespace SportsBetting.Web.Controllers
{
    [Route("api/[controller]")]
    public class EventsDataController : Controller
    {
        private readonly IEventService eventService;

        public EventsDataController(IEventService eventService)
        {

            if (eventService == null)
            {
                throw new ArgumentNullException("EventService can not be null!");
            }

            this.eventService = eventService;

        }

        [HttpGet("[action]")]
        public IEnumerable<Event> Events()
        {

            var ev1 = new Event()
            {
                EventID = 1,
                EventName = "Juventus - Inter Milan",
                EventStartDate = new DateTime(2018,12,25), // "25/12/2018",
                OddsForFirstTeam = 1.95,
                OddsForDraw = 3.10,
                OddsForSecondTeam = 2.50
            };

            var ev2 = new Event()
            {
                EventID = 2,
                EventName = "Barcelona - Real Madrid",
                EventStartDate = new DateTime(2018, 12, 20), // "20/12/2018",
                OddsForFirstTeam = 2.15,
                OddsForDraw = 3.50,
                OddsForSecondTeam = 2.00
            };
            var ev3 = new Event()
            {
                EventID = 3,
                EventName = "Bayern Munich - Real Madrid",
                EventStartDate = new DateTime(2018, 10, 09),// "10/09/2018",
                OddsForFirstTeam = 2.75,
                OddsForDraw = 3.30,
                OddsForSecondTeam = 1.75,
                
            };
            var ev4 = new Event()
            {
                EventID = 4,
                EventName = "Paris Saint-Germain - Olympique de Marseille",
                EventStartDate = new DateTime(2003, 11, 12), //"11/12/2018",
                OddsForFirstTeam = 1.45,
                OddsForDraw = 3.93,
                OddsForSecondTeam = 3.75
            };

            this.eventService.AddEvent(ev1);
            this.eventService.AddEvent(ev2);
            this.eventService.AddEvent(ev3);
            this.eventService.AddEvent(ev4);

            return new List<Event>() { ev1,ev2,ev3,ev4 };
        }

 
    }
}
