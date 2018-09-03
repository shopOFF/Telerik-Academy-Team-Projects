using SportsBetting.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsBetting.Data.Models
{
    public class Event : IEvent
    {
        private bool isEventPassed;

        [Key]
        public Guid Id { get; set; }
        public int EventID { get; set; }

        [MaxLength(300)]
        public string EventName { get; set; }
        public double OddsForFirstTeam { get; set; }
        public double OddsForDraw { get; set; }
        public double OddsForSecondTeam { get; set; }

        [DataType(DataType.Date)]
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
