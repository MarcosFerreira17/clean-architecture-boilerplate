using Template.Domain.Common;

namespace Template.Domain.Entities;

public class TemplateEntity : EntityBase<long>
{
    public string ExampleString { get; set; }
}
