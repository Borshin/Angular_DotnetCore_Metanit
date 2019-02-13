/**Airline class. */
export class Airline {
    /**
     * Constructor.
     * @param name Name of the airline.
     * @param alias Alias of the airline.For example, All Nippon Airways is commonly known as "ANA".
     * @param active True if the airline is or has until recently been operational, otherwise it is defunct.
     */
    constructor(
        name: string = null,
        alias: string = null,
        active: boolean = null,
    ) {
        this.name = name;
        this.alias = alias;
        this.active = active;
    }
    /**Name of the airline. */
    public name: string;
    /**Alias of the airline.For example, All Nippon Airways is commonly known as "ANA". */
    public alias: string;
    /**True if the airline is or has until recently been operational, otherwise it is defunct. */
    public active: boolean;
}