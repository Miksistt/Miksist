using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Range(0, 1000000)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int Quantity { get; set; }
}
