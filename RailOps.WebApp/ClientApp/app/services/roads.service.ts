import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { Road } from '../models/roster/road';

@Injectable()
export class RoadService {
    constructor(
        private http: Http) 
    { }

    getRoads(): Observable<Road[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let url = "http://localhost:50225/api/roads";

        return this.http.get(url, options)
            .map((response: Response) => response.json() as Road[]);
    }

    createRoad(road: Road): Observable<Road> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let url = 'http://localhost:50225/api/roads';

        let data = {
            name: road.name,
            code: road.code
        };

        return this.http.post(url, JSON.stringify(data), options)
            .map((response: Response) => response.json() as Road);
    }
}