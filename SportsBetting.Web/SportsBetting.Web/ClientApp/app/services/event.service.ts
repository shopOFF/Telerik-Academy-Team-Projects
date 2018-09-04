import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Response, Headers, Request } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { IEvent } from '../models/IEvent';

@Injectable()
export class EventService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }


    getEvents(): Observable<IEvent[]> {
        return this.http.get(`${this.baseUrl}api/EventsData/GetEvents`)
            .map((response: Response) => response.json() as IEvent[]);
    }

    addEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(`${this.baseUrl}api/EventsData/AddEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }

    updateEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(`${this.baseUrl}api/EventsData/UpdateEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }

    deleteEvent(editEvent: IEvent): Observable<IEvent[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(`${this.baseUrl}api/EventsData/DeleteEvent`, editEvent, options)
            .map((response: Response) => response.json());
    }
}