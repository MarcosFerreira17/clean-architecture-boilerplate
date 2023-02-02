using System.ComponentModel.DataAnnotations;

namespace Costumer.Domain.Dtos;
public record AddressDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(100, MinimumLength = 3)]
    public string Street { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(60, MinimumLength = 3)]
    public string City { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(60, MinimumLength = 3)]
    public string State { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(60, MinimumLength = 3)]
    public string Country { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(10, MinimumLength = 8)]
    public string ZipCode { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(120, MinimumLength = 4)]
    public string Neighborhood { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [Range(1, 10000)]
    public int Number { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    public string Complement { get; set; }
}
