using Microsoft.Extensions.Caching.Memory;
using PathFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PathFinder.Services
{
    public class PathFinderSevice: IPathFinder{
        /// <summary>
        /// Flight service.
        /// </summary>
        private IFlightsService _flightService;
        /// <summary>
        /// Memory cache.
        /// </summary>
        private readonly IMemoryCache _cache;
        private readonly int _cacheExpireTime;

        private readonly object _isCancelledLock = new object();
        /// <summary>
        /// Terminates requests.
        /// </summary>
        private volatile bool _terminateRequests;
        private List<AirRoute> _resultPath;

        public PathFinderSevice(IMemoryCache cache, IFlightsService flightService)
        {
            _flightService = flightService;
            _cache = cache;
            _cacheExpireTime = 10;
            _resultPath = new List<AirRoute>();
        }

        /// <summary>
        /// Main method that is used to find route between source and destination airport using https://homework.appulate.com/
        /// </summary>
        /// <param name="srcAirport">3-letter (IATA) or 4-letter (ICAO) code of the source airport.</param>
        /// <param name="destAirport">3-letter (IATA) or 4-letter (ICAO) code of the destination airport.</param>
        /// <param name="crumbs">List of routes where we have been.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of AirRoute info. </returns>
        public async Task<List<AirRoute>> Find(string airport, string destAirport, List<AirRoute> crumbs)
        {
            if (_terminateRequests)
            {
                return null;
            }

            var airRoutes = await GetAirRoutes(airport);

            if (airRoutes.Any(route => route.DestAirport == destAirport))
            {
                var finalRoute = airRoutes.Find(route => route.DestAirport == destAirport);
                _resultPath.Add(finalRoute);
                _terminateRequests = true;
                return _resultPath;
            }

            foreach (var crumb in airRoutes)
            {
                if (_terminateRequests)
                {
                    break;
                }

                if(crumbs!= null && crumbs.Any(route=>route.Airline == crumb.Airline))
                {
                    continue;
                }

                var newCrumbs = new List<AirRoute>();
                if (crumbs != null)
                {
                    newCrumbs.AddRange(crumbs);
                }
                newCrumbs.Add(crumb);

                var res = await Find(crumb.DestAirport, destAirport, newCrumbs);
                if (res!=null && res.Any(route => route.DestAirport == destAirport))
                {
                    _resultPath.Add(crumb);
                    return _resultPath;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets air routes.
        /// </summary>
        /// <param name="airport">Airport. </param>
        /// <returns>List of AirRoutes. </returns>
        private async Task<List<AirRoute>> GetAirRoutes(string airport)
        {
            if (!_cache.TryGetValue($"{airport}-routes", out List<AirRoute> airRoutes))
            {
                airRoutes = await _flightService.GetRouteOutgoingInfo(airport);
                _cache.Set($"{airport}-routes", airRoutes, TimeSpan.FromMinutes(_cacheExpireTime));
            }

            List<Task> tasks = new List<Task>();
            List<Airline> airLines = new List<Airline>();
            foreach (var route in airRoutes)
            {
                var res = await _flightService.GetAirlineInfo(route.Airline);
                airLines.Add(res.FirstOrDefault());
            }
            if (airRoutes == null)
            {
                return null;
            }
            var result = airRoutes.Where(airRoute => airLines.Any(airline => (airline.Alias == airRoute.Airline) && (airline.Active)));

            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }

    }
}
