using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public record class EntityDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public long Id { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    public string Example { get; set; }
}
