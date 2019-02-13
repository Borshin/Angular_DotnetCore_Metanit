/// <summary>
/// Airline class.
/// </summary>
public class Airline
{
    /// <summary>
    /// Name of the airline.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Alias of the airline.For example, All Nippon Airways is commonly known as "ANA".
    /// </summary>
    public string Alias { get; set; }
    /// <summary>
    /// True if the airline is or has until recently been operational, otherwise it is defunct.
    /// </summary>
    public bool Active { get; set; }
}
