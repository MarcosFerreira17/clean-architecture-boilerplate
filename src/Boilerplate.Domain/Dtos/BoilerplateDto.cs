using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Domain.Dtos;

public record class BoilerplateDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public long Id { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    public string ExampleString { get; set; }
}
