/// <summary>
/// AirRoute class.
/// </summary>
public class AirRoute
{
    /// <summary>
    /// 2-letter (IATA) or 3-letter (ICAO) code of the airline.
    /// </summary>
    public string Airline { get; set; }
    /// <summary>
    /// 3-letter (IATA) or 4-letter (ICAO) code of the source airport.
    /// </summary>
    public string SrcAirport { get; set; }
    /// <summary>
    /// 3-letter (IATA) or 4-letter (ICAO) code of the destination airport.
    /// </summary>
    public string DestAirport { get; set; }
}