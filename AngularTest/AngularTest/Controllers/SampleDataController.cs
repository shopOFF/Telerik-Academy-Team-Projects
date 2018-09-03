using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularTest.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static IList<Event> eventList;

        public SampleDataController()
        {
            eventList = new List<Event>();
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Event> WeatherForecasts()
        {
            var ev1 = new Event()
            {
                EventID = 1,
                EventName = "Juventus - Inter Milan",
                EventStartDate = new DateTime(2018, 12, 25), // "25/12/2018",
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

            eventList.Add(ev1);
            eventList.Add(ev2);
            eventList.Add(ev3);
            eventList.Add(ev4);

            return eventList;
        }

        [HttpPost("[action]")]
        public IActionResult AddEvent(Event ev)
        {

            eventList.Add(ev);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateEvent(Event ev)
        {

           // var eventToUpdate = eventList.Where(x => x.EventID == ev.EventID).FirstOrDefault();
            //.....
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult DeleteEvent(Event ev)
        {
            //var eventToUpdate = eventList.Where(x => x.EventID == ev.EventID).FirstOrDefault();
            //.....
            return Ok();
        }

        public class Event
        {
            private bool isEventPassed;


            public Guid Id { get; set; }
            public int EventID { get; set; }

            public string EventName { get; set; }
            public double OddsForFirstTeam { get; set; }
            public double OddsForDraw { get; set; }
            public double OddsForSecondTeam { get; set; }

            public DateTime EventStartDate { get; set; }

            public bool IsEventPassed
            {
                get { return this.DetermineIfEventIsPassed(); }
            }

            private bool DetermineIfEventIsPassed()
            {
                var result = DateTime.Compare(this.EventStartDate, DateTime.Now);
                if (result < 0)
                {
                    this.isEventPassed = true;
                }
                else
                {
                    this.isEventPassed = false;
                }

                return isEventPassed;
            }
        }
    }
}
