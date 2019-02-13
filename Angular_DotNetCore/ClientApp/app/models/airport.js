/**Airport class. */
var Airport = /** @class */ (function () {
    /**
     * Constructor.
     * @param name Name of airport.May or may not contain the City name.
     * @param alias Alias of the airline.For example, All Nippon Airways is commonly known as "ANA".
     * @param city Main city served by airport.May be spelled differently from Name.
     * @param country Main city served by airport.May be spelled differently from Name.
     * @param latitude Country or territory where airport is located.See countries.dat to cross - reference to ISO 3166 - 1 codes.
     * @param longitude Decimal degrees, usually to six significant digits.Negative is South, positive is North.
     * @param altitude In feet.
     */
    function Airport(name, alias, city, country, latitude, longitude, altitude) {
        if (name === void 0) { name = null; }
        if (alias === void 0) { alias = null; }
        if (city === void 0) { city = null; }
        if (country === void 0) { country = null; }
        if (latitude === void 0) { latitude = null; }
        if (longitude === void 0) { longitude = null; }
        if (altitude === void 0) { altitude = null; }
        this.name = name;
        this.alias = alias;
        this.city = city;
        this.country = country;
        this.latitude = latitude;
        this.longitude = longitude;
        this.altitude = altitude;
    }
    return Airport;
}());
export { Airport };
//# sourceMappingURL=airport.js.map