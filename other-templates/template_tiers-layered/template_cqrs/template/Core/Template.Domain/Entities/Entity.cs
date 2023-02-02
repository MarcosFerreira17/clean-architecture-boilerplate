using Template.Domain.Common;

namespace Template.Domain.Entities;

public class Entity : EntityBase<long>
{
    public string Example { get; set; }
}
