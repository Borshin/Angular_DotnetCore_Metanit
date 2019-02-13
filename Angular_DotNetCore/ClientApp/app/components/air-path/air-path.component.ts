import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { Airport } from '../../models/airport';
import { Airline } from '../../models/airline';
import { AirRoute } from '../../models/air-route';

@Component({
    styleUrls: ['./air-path.component.css'],
    templateUrl: './air-path.component.html',
})
export class AirPathComponent implements OnInit {
    /**Arrival point. */
    public srcAirport: Airport;
    /**Destination point. */
    public destAirport: Airport;

    /**Array of airline info. */
    airlineInfo: Airline[] = [];

    /**Array of airport outgoing routes. */
    airportOutgoingRoutes: AirRoute[] = [];

    /**Array of airport info. */
    airportInfo: Airport[] = [];

    /**Array of paths. */
    airportPath: AirRoute[] = [];


    constructor(private dataService: DataService) {
    }

    ngOnInit() {
    }


    /**
     * Gets airline info from api.
     * @param alias Airport alias.
     */
    public getAirlineInfo(alias: string) {
        this.dataService.getAirlineInfo(alias)
            .subscribe((res: any) => {
                if (res) {
                    this.airlineInfo = res.data;
                }
            });
    }

    /**
     * Gets airport outgoing routes from api.
    * @param airport Airport alias.
    */
    public getAirportOutgoing(airport: string) {
        this.dataService.getAirportOutgoing(airport)
            .subscribe((res: any) => {
                if (res) {
                    this.airportOutgoingRoutes = res.data;
                }
            })
    }

    /**
    * Gets airport info from api.
    * @param pattern Pattern.
    */
    public getAirportInfo(pattern: string) {
        this.dataService.getAirportInfo(pattern)
            .subscribe((res: any) => {
                if (res) {
                    this.airportInfo = res.data;
                }
            })
    }

   /**
    * Gets path.
    * @param sourceAirport Source airport.
    * @param destinationAirport Destination airport.
    */
    public getPath(sourceAirport: string, destinationAirport: string) {
        this.dataService.findPath(sourceAirport, destinationAirport)
            .subscribe((res: any) => {
                if (res) {
                    this.airportPath = res.data;
                }
            })
    }
    
}