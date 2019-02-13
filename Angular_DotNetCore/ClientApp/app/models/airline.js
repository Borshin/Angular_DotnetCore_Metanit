/**Airline class. */
var Airline = /** @class */ (function () {
    /**
     * Constructor.
     * @param name Name of the airline.
     * @param alias Alias of the airline.For example, All Nippon Airways is commonly known as "ANA".
     * @param active True if the airline is or has until recently been operational, otherwise it is defunct.
     */
    function Airline(name, alias, active) {
        if (name === void 0) { name = null; }
        if (alias === void 0) { alias = null; }
        if (active === void 0) { active = null; }
        this.name = name;
        this.alias = alias;
        this.active = active;
    }
    return Airline;
}());
export { Airline };
//# sourceMappingURL=airline.js.map