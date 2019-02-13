var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
/**Data service. */
var DataService = /** @class */ (function () {
    /**
     * Constructor.
     * @param http Http client.
     */
    function DataService(http) {
        this.http = http;
        /**Base url. */
        this.url = 'api/pathfinder';
    }
    /**
     * Gets airline info.
     * @param alias Airport alias.
     * @returns Array of airlines.
     */
    DataService.prototype.getAirlineInfo = function (alias) {
        return this.http.get(this.url + '/airline/' + alias);
    };
    /**
     * Gets airport outgoing routes.
     * @param airport Airport.
     * @returns Array of routes.
     */
    DataService.prototype.getAirportOutgoing = function (airport) {
        return this.http.get(this.url + '/' + airport + '/outgoing');
    };
    /**
     * Gets Airport info.
     * @param pattern Pattern.
     * @returns Array of airport infos.
     */
    DataService.prototype.getAirportInfo = function (pattern) {
        return this.http.get(this.url + '/airport/' + pattern);
    };
    /**
     * Finds path.
     * @param sourceAirport Source airport.
     * @param destinationAirport Destination airport.
     * @return Path.
     */
    DataService.prototype.findPath = function (sourceAirport, destinationAirport) {
        return this.http.get(this.url + '/path', { params: { sourceAirport: sourceAirport, destinationAirport: destinationAirport } });
    };
    DataService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=data.service.js.map