using PathFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PathFinder.Services
{
    public class FlightsService: IFlightsService
    {
        /// <summary>
        ////Http client.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Base address.
        /// </summary>
        private string _baseAddress = "https://homework.appulate.com/api/";
       
        /// <summary>
        /// Constructor. 
        /// </summary>
        public FlightsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets Airline info from /api/Airline/{<paramref name="alias"/>}.
        /// </summary>
        /// <param name="alias">Airline alias.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of Airline info. </returns>
        public async Task<List<Airline>> GetAirlineInfo(string alias)
        {
            List<Airline> result = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Airline/{alias}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<Airline>>();
            }
            return result;
        }

        /// <summary>
        /// Gets route info from /api/Route/outgoing.
        /// </summary>
        /// <param name="airport">Airport alias.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of available routes from airport. </returns>
        public async Task<List<AirRoute>> GetRouteOutgoingInfo(string airport)
        {
            List<AirRoute> result = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Route/outgoing?airport={airport}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<AirRoute>>();
            }
            return result;
        }

        /// <summary>
        /// Gets Airport info from /api/Airport/search by <paramref name="pattern"/>.
        /// </summary>
        /// <param name="pattern">Pattern.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains list of Airport info. </returns>
        public async Task<List<Airport>> GetAirportInfo(string pattern)
        {
            List<Airport> result = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Airport/search?pattern={pattern}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<Airport>>();
            }
            return result;
        }
    }
}
