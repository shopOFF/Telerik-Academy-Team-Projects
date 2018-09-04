import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Response, Headers,Request } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class EventService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }


    getEvents(): Observable<IEvent[]> {
        return this.http.get(`${this.baseUrl}api/SampleData/WeatherForecasts`)
            .map((response: Response) => response.json() as IEvent[]);
    }

    addEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(`${this.baseUrl}api/SampleData/AddEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }

    updateEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(`${this.baseUrl}api/SampleData/UpdateEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }

    deleteEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(`${this.baseUrl}api/SampleData/DeleteEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }
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