/// <summary>
/// Airport class.
/// </summary>
public class Airport
{
    /// <summary>
    /// Name of airport.May or may not contain the City name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Alias of the airline.For example, All Nippon Airways is commonly known as "ANA".
    /// </summary>
    public string Alias { get; set; }
    /// <summary>
    /// Main city served by airport.May be spelled differently from Name.
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Country or territory where airport is located.See countries.dat to cross - reference to ISO 3166 - 1 codes.
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Decimal degrees, usually to six significant digits.Negative is South, positive is North.
    /// </summary>
    public decimal Latitude { get; set; }
    /// <summary>
    /// Decimal degrees, usually to six significant digits.Negative is West, positive is East.
    /// </summary>
    public decimal Longitude { get; set; }
    /// <summary>
    /// In feet.
    /// </summary>
    public long Altitude { get; set; }
}