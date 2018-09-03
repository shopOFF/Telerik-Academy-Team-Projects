import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'getevents',
    templateUrl: './getevents.component.html',
    styleUrls: ['./getevents.component.css']
})

export class GetEventsComponent {
    //editField: string;
    //personList: Array<any> = [
    //    { id: 1, name: 'Aurelia Vega', age: 30, companyName: 'Deepends', country: 'Spain', city: 'Madrid' },
    //    { id: 2, name: 'Guerra Cortez', age: 45, companyName: 'Insectus', country: 'USA', city: 'San Francisco' },
    //    { id: 3, name: 'Guadalupe House', age: 26, companyName: 'Isotronic', country: 'Germany', city: 'Frankfurt am Main' },
    //    { id: 4, name: 'Aurelia Vega', age: 30, companyName: 'Deepends', country: 'Spain', city: 'Madrid' },
    //    { id: 5, name: 'Elisa Gallagher', age: 31, companyName: 'Portica', country: 'United Kingdom', city: 'London' },
    //];

    //awaitingPersonList: Array<any> = [
    //    { id: 6, name: 'George Vega', age: 28, companyName: 'Classical', country: 'Russia', city: 'Moscow' },
    //    { id: 7, name: 'Mike Low', age: 22, companyName: 'Lou', country: 'USA', city: 'Los Angeles' },
    //    { id: 8, name: 'John Derp', age: 36, companyName: 'Derping', country: 'USA', city: 'Chicago' },
    //    { id: 9, name: 'Anastasia John', age: 21, companyName: 'Ajo', country: 'Brazil', city: 'Rio' },
    //    { id: 10, name: 'John Maklowicz', age: 36, companyName: 'Mako', country: 'Poland', city: 'Bialystok' },
    //];


    //remove(id: any) {
    //    this.awaitingPersonList.push(this.personList[id]);
    //    this.personList.splice(id, 1);
    //}

    //add() {
    //    if (this.awaitingPersonList.length > 0) {
    //        const person = this.awaitingPersonList[0];
    //        this.personList.push(person);
    //        this.awaitingPersonList.splice(0, 1);
    //    }
    //}

    //changeValue(id: number, property: string, event: any) {
    //    this.editField = event.target.textContent;
    //    this.editEvent[id].eventName = this.editField;
    //}


    //public previewEvent: PreviewEvent[];

    private show: boolean = false;
    private buttonName: any = 'Edit Mode';

    toggle() {
        this.show = !this.show;

        if (this.show) {
            this.buttonName = "Preview Mode";
        }
        else {
            this.buttonName = "Edit Mode";
        }
    }


    public editEvent: IEvent[];

    addNewEvent() {
        let newEvent: IEvent = {
            eventID: Math.floor(Math.random() * 666) + 1,
            eventStartDate: new Date()
        };

        let previewEvent = new PreviewEvent();
        previewEvent.eventID = Math.floor(Math.random() * 666) + 1;
        previewEvent.eventStartDate = new Date();

        this.editEvent.push(newEvent);
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/EventsData/Events').subscribe(result => {
            // this.previewEvent = result.json() as PreviewEvent[];
            this.editEvent = result.json() as IEvent[];
            console.log(this.editEvent);

        }, error => console.error(error));
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
