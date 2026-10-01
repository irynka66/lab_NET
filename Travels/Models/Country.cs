using System.ComponentModel.DataAnnotations;

namespace Travels.Models;

public class Country
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Зазначте назву країни")]
    public string Name { get; set; } = "";
}