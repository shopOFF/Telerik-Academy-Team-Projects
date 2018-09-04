import { Component, Inject, OnInit } from '@angular/core';
import { Http, RequestOptions, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { EventService } from './services/event.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    styleUrls: ['./fetchdata.component.css'],
    providers: [EventService]
})

export class FetchDataComponent implements OnInit {
    private show: boolean = false;
    private buttonName: any = 'Edit Mode';
    private result: any[];

    toggle() {
        this.show = !this.show;

        if (this.show) {
            this.buttonName = "Preview Mode";
        }
        else {
            this.buttonName = "Edit Mode";
        }
    }

    saveChanges(name: any) {
        this.editEvent = name;
        console.log(this.editEvent);



    }

    public editEvent: IEvent[];

    addNewEvent() {
        let newEvent: IEvent = {
            eventID: Math.floor(Math.random() * 666) + 1,
            eventStartDate: new Date(),
            eventName: "TESTING"
        };

        let previewEvent = new PreviewEvent();
        previewEvent.eventID = Math.floor(Math.random() * 666) + 1;
        previewEvent.eventStartDate = new Date();

        this.editEvent.push(newEvent);
    }


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private eventService: EventService) {

    }

    ngOnInit() {
        let newEvent: IEvent = {
            eventID: Math.floor(Math.random() * 666) + 1,
            eventStartDate: new Date(),
            eventName: "TESTING"
        };

        this.eventService.getEvents()
            .subscribe((events) => this.editEvent = events);

        //this.eventService.addEvent(newEvent)
        //    .subscribe((events) => this.editEvent = events);

        //this.eventService.updateEvent(newEvent)
        //    .subscribe((events) => this.editEvent = events);

        //this.eventService.deleteEvent(newEvent)
        //    .subscribe((events) => this.editEvent = events);
    }

}

class PreviewEvent implements IEvent {
    eventID: number;
    eventName?: string | undefined;
    oddsForFirstTeam?: number | undefined;
    oddsForDraw?: number | undefined;
    oddsForSecondTeam?: number | undefined;
    isEventPassed?: boolean | undefined;
    eventStartDate: Date;

}

interface IEvent {
    eventID: number;
    eventName?: string;
    oddsForFirstTeam?: number;
    oddsForDraw?: number;
    oddsForSecondTeam?: number;
    isEventPassed?: boolean;
    eventStartDate: Date;
}