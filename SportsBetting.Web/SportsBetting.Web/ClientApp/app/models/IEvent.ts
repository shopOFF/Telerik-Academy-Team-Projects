export interface IEvent {
    eventID: number;
    eventName?: string;
    oddsForFirstTeam?: number;
    oddsForDraw?: number;
    oddsForSecondTeam?: number;
    isEventPassed?: boolean;
    eventStartDate: Date;
}