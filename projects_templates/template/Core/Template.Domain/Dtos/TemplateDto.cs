using System.ComponentModel.DataAnnotations;

namespace Template.Domain.Dtos;

public record class TemplateDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public long Id { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    public string ExampleString { get; set; }
}
