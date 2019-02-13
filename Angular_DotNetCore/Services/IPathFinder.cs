using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathFinder.Services
{
    /// <summary>
    /// Path finder interface.
    /// </summary>
    public interface IPathFinder
    {
        /// <summary>
        /// Find path from <paramref name="sourceAirport"/> to <paramref name="destAirport"/>
        /// </summary>
        /// <param name="srcAirport">Source airport.</param>
        /// <param name="destAirport">Destination airport.</param>
        /// <param name="crumbs">List of routes where we have been.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of AirRoute info. </returns>
        Task<List<AirRoute>> Find(string srcAirport, string destAirport, List<AirRoute> crumbs);
    }

}
