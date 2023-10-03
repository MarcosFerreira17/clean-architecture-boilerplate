using Boilerplate.Domain.Common;

namespace Boilerplate.Domain.Entities;

public class BoilerplateEntity : EntityBase<long>
{
    public string ExampleString { get; set; }
}
