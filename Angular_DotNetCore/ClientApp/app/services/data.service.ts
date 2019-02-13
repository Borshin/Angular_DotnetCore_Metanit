import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AirRoute } from '../models/air-route';

/**Data service. */
@Injectable()
export class DataService {
    /**Base url. */
    private url = 'api/pathfinder';
    /**
     * Constructor. 
     * @param http Http client.
     */
    constructor(private http: HttpClient) {
    }

    /**
     * Gets airline info.
     * @param alias Airport alias.
     * @returns Array of airlines.
     */
    getAirlineInfo(alias: string): Observable<any> {
        return this.http.get(this.url + '/airline/' + alias);
    }

    /**
     * Gets airport outgoing routes.
     * @param airport Airport.
     * @returns Array of routes.
     */
    getAirportOutgoing(airport: string): Observable<any> {
        return this.http.get(this.url + '/' + airport + '/outgoing');
    }

    /**
     * Gets Airport info.
     * @param pattern Pattern.
     * @returns Array of airport infos.
     */
    getAirportInfo(pattern: any): Observable<any> {
        return this.http.get(this.url + '/airport/' + pattern);
    }

    /**
     * Finds path.
     * @param sourceAirport Source airport.
     * @param destinationAirport Destination airport.
     * @return Path.
     */
    findPath(sourceAirport: string, destinationAirport: string): Observable<any> {
        return this.http.get(this.url + '/path', { params: { sourceAirport: sourceAirport, destinationAirport: destinationAirport }}); 
    }
}