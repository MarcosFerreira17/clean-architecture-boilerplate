using System.ComponentModel.DataAnnotations;

namespace Costumer.Domain.Dtos;

public record PersonDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public DateTime Birthdate { get; set; }

    [EmailAddress(ErrorMessage = "Invalid format Email")]
    [Required(ErrorMessage = "The field {0} is required")]
    public string Email { get; set; }
    public AddressDto Address { get; set; }
}
