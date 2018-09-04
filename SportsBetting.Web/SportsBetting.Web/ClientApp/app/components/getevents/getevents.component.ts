import { Component, Inject, OnInit, OnChanges } from '@angular/core';
import { EventService } from '../../services/event.service';
import { IEvent } from '../../models/IEvent';

@Component({
    selector: 'getevents',
    templateUrl: './getevents.component.html',
    styleUrls: ['./getevents.component.css'],
    providers: [EventService]
})

export class GetEventsComponent implements OnInit {
    private show: boolean = false;
    private buttonName: any = 'Edit Mode';
    private eventCollection: IEvent[];

    constructor(private eventService: EventService) {
    }

    ngOnInit() {
        this.eventService.getEvents()
            .subscribe((events) => this.eventCollection = events);
    }

    toggle() {
        this.show = !this.show;

        if (this.show) {
            this.buttonName = "Preview Mode";
        }
        else {
            this.buttonName = "Edit Mode";
        }
    }

    deleteEvent(id: number) {
        let eventToDelete = this.eventCollection.filter(x => x.eventID == id)[0];
        let index = this.eventCollection.indexOf(eventToDelete, 0);
        this.eventCollection.splice(index, 1);

        this.eventService.deleteEvent(eventToDelete)
            .subscribe((events) => this.eventCollection = events);
    }

    addNewEvent() {
        let newEvent: IEvent = {
            eventID: Math.floor(Math.random() * 666) + 1,
            eventStartDate: new Date()
        };

        this.eventService.addEvent(newEvent)
            .subscribe((events) => this.eventCollection = events);

        this.eventCollection.push(newEvent);
        location.reload();
    }

    saveChanges(id: number, row: any) {
        let eventToUpdate = this.eventCollection.filter(x => x.eventID == id)[0];

        eventToUpdate.eventName = row.cells[1].innerHTML;
        eventToUpdate.oddsForFirstTeam = parseFloat(row.cells[2].innerHTML);
        eventToUpdate.oddsForDraw = parseFloat(row.cells[3].innerHTML);
        eventToUpdate.oddsForSecondTeam = parseFloat(row.cells[4].innerHTML);
        eventToUpdate.eventStartDate = new Date(row.cells[5].innerHTML);

        this.eventService.updateEvent(eventToUpdate)
            .subscribe((events) => this.eventCollection = events);

        location.reload();
    }

}
