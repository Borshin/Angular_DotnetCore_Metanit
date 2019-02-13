using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PathFinder.Services;
using PathFinder.Filters;
using System.Linq;

namespace PathFinder.Controllers
{
    /// <summary>
    /// PathFinder controller.
    /// </summary>
    [Route("api/pathfinder")]
    public class PathFinderController : Controller
    {
        /// <summary>
        /// Flight service.
        /// </summary>
        private readonly IFlightsService _flightsService;
        /// <summary>
        /// PathFinder service.
        /// </summary>
        private readonly IPathFinder _pathFinder;
        /// <summary>
        /// Logger.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="flightsService">Flight service.</param>
        /// <param name="loggerFactory">Logger.</param>
        /// <param name="pathFinder">PathFinder service.</param>
        public PathFinderController(IFlightsService flightsService, ILoggerFactory loggerFactory, IPathFinder pathFinder)
        {
            _flightsService = flightsService;
            _pathFinder = pathFinder;
            _logger = loggerFactory.CreateLogger(typeof(PathFinderController));
        }

        /// <summary>
        /// Searches airline info by <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">Airport alias.</param>
        /// <returns>Airport info.</returns>
        [HttpGet("airline/{alias}")]
        [JsonArrayFilter]
        public async Task<IActionResult> GetAirlineInfo(string alias)
        {
            var result = await _flightsService.GetAirlineInfo(alias);

            return Json(result);
        }

        /// <summary>
        /// Searches routes outgoing info by <paramref name="airport"/>.
        /// </summary>
        /// <param name="airport">Airport alias.</param>
        /// <returns>Route info.</returns>
        [HttpGet("{airport}/outgoing")]
        [JsonArrayFilter]
        public async Task<IActionResult> GetAirportOutgoing(string airport)
        {
            var result = await _flightsService.GetRouteOutgoingInfo(airport);

            return Json(result);
        }

        /// <summary>
        /// Searches airport info by <paramref name="pattern"/>.
        /// </summary>
        /// <param name="pattern">Airport alias.</param>
        /// <returns>Airport info.</returns>
        [HttpGet("airport/{pattern}")]
        [JsonArrayFilter]
        public async Task<IActionResult> GetAirportInfo(string pattern)
        {
            var result = await _flightsService.GetAirportInfo(pattern);

            return Json(result);
        }

        /// <summary>
        /// Searches path between <paramref name="sourceAirport"/> and <paramref name="destinationAirport"/>.
        /// </summary>
        /// <param name="sourceAirport">3-letter (IATA) or 4-letter (ICAO) code of the source airport. </param>
        /// <param name="destinationAirport">3-letter (IATA) or 4-letter (ICAO) code of the destination airport. </param>
        /// <returns>Returns list of airports where each line is equal to one hop.</returns>
        [HttpGet("path")]
        [JsonArrayFilter]
        public async Task<ActionResult> Get(string sourceAirport, string destinationAirport)
        {
            var result = await _pathFinder.Find(sourceAirport, destinationAirport, null);
            if (result!=null && result.Any())
            {
                return Json(result);
            }
            return NotFound("Path not found.");
        }
    }
}
