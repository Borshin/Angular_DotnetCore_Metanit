/**AirRoute class. */
export class AirRoute {
    /**
     * Constructor. 
     * @param airline 2-letter(IATA) or 3 - letter(ICAO) code of the airline.
     * @param srcAirport 3 - letter(IATA) or 4 - letter(ICAO) code of the source airport.
     * @param destAirport 3 - letter(IATA) or 4 - letter(ICAO) code of the destination airport.
     */
    constructor(
        airline: string = null,
        srcAirport: string = null,
        destAirport: string = null,
    ) {
        this.airline = airline;
        this.srcAirport = srcAirport;
        this.destAirport = destAirport;
    }

    /**2-letter(IATA) or 3 - letter(ICAO) code of the airline. */
    airline: string;
    
    /**3 - letter(IATA) or 4 - letter(ICAO) code of the source airport. */
    srcAirport:	string;

    /**3 - letter(IATA) or 4 - letter(ICAO) code of the destination airport. */
    destAirport: string;
}