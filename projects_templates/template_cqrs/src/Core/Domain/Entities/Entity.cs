using Domain.Common;

namespace Domain.Entities;

public class Entity : EntityBase<long>
{
    public string Example { get; set; }
}
