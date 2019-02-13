using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinder.Services
{
    /// <summary>
    /// Flight service interface.
    /// </summary>
    public interface IFlightsService
    {
        /// <summary>
        /// Gets Airline info from /api/Airline/{<paramref name="alias"/>}.
        /// </summary>
        /// <param name="alias">Airline alias.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of Airline info. </returns>
        Task<List<Airline>> GetAirlineInfo(string alias);

        /// <summary>
        /// Gets Route info from /api/Route/outgoing.
        /// </summary>
        /// <param name="airport">Airport alias.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of available routes from airport. </returns>
        Task<List<AirRoute>> GetRouteOutgoingInfo(string airport);

        /// <summary>
        /// Gets Airport info from /api/Airport/search by <paramref name="pattern"/>.
        /// </summary>
        /// <param name="pattern">Pattern.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of Airport info. </returns>
        Task<List<Airport>> GetAirportInfo(string pattern);
    }
}
