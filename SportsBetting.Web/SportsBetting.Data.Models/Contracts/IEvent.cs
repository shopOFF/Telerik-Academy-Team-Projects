using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Models.Contracts
{
    public interface IEvent
    {
        Guid Id { get; set; }
        int EventID { get; set; }
        string EventName { get; set; }
        double OddsForFirstTeam { get; set; }
        double OddsForDraw { get; set; }
        double OddsForSecondTeam { get; set; }
        DateTime EventStartDate { get; set; }
        bool IsEventPassed { get; }
    }
}
