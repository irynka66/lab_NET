using System.ComponentModel.DataAnnotations;

namespace Travels.Models;

public class Transport
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Зазначте вид транспорту")]
    public string Name { get; set; } = "";
}