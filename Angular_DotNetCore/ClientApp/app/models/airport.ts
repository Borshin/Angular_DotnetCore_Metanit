/**Airport class. */
export class Airport {
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
    constructor(
        name: string = null,
        alias: string = null,
        city: string = null,
        country: string = null,
        latitude: number = null,
        longitude: number = null,
        altitude: number = null,
    ) {
        this.name = name;
        this.alias = alias;
        this.city = city;
        this.country = country;
        this.latitude = latitude;
        this.longitude = longitude;
        this.altitude = altitude;
    }
    /**Name of airport.May or may not contain the City name. */
    name: string;

    /**Alias of the airline.For example, All Nippon Airways is commonly known as "ANA". */
    alias: string;

    /**Main city served by airport.May be spelled differently from Name. */
    city: string;

    /**Country or territory where airport is located.See countries.dat to cross - reference to ISO 3166 - 1 codes. */
    country: string;

    /**Decimal degrees, usually to six significant digits.Negative is South, positive is North. */
    latitude: number;

    /**Decimal degrees, usually to six significant digits.Negative is West, positive is East. */
    longitude: number;

    /**In feet. */
    altitude: number;
}