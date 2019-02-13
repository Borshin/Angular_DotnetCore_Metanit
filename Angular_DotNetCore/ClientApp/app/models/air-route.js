/**AirRoute class. */
var AirRoute = /** @class */ (function () {
    /**
     * Constructor.
     * @param airline 2-letter(IATA) or 3 - letter(ICAO) code of the airline.
     * @param srcAirport 3 - letter(IATA) or 4 - letter(ICAO) code of the source airport.
     * @param destAirport 3 - letter(IATA) or 4 - letter(ICAO) code of the destination airport.
     */
    function AirRoute(airline, srcAirport, destAirport) {
        if (airline === void 0) { airline = null; }
        if (srcAirport === void 0) { srcAirport = null; }
        if (destAirport === void 0) { destAirport = null; }
        this.airline = airline;
        this.srcAirport = srcAirport;
        this.destAirport = destAirport;
    }
    return AirRoute;
}());
export { AirRoute };
//# sourceMappingURL=air-route.js.map