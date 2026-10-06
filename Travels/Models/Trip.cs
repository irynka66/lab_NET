using System.ComponentModel.DataAnnotations;
namespace Travels.Models;

public class Trip
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Зазначте місце призначення")]
    [StringLength(150, ErrorMessage = "Назва місця задовга")]
    public string Destination { get; set; } = "";
    public string DestinationSearch { get; set; } = "";

    public string? Description { get; set; }

    [Required(ErrorMessage = "Вкажіть дату початку поїздки")]
    public DateOnly StartDate { get; set; }

    [Required(ErrorMessage = "Вкажіть дату завершення поїздки")]
    public DateOnly EndDate { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Вартість має бути більшою за нуль")]
    public decimal TotalCost { get; set; }

    public bool IsBusinessTrip { get; set; }

    public int CountryId { get; set; }
    public Country? Country { get; set; }

    public int TransportId { get; set; }
    public Transport? Transport { get; set; }

    public TripStatus Status { get; set; }
}