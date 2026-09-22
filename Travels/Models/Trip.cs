namespace Travels.Models;

public class Trip
{
    public int Id { get; set; }

    public string Destination { get; set; } = "";

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal TotalCost { get; set; }

    public bool IsBusinessTrip { get; set; }

    public TripStatus Status { get; set; }
}