using Costumer.Domain.Common;
using Costumer.Domain.ValueObjects;

namespace Costumer.Domain.Entities;

public class Person : EntityBase<long>
{
    public string Name { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string Email { get; private set; }
    public Address Address { get; private set; }

    public override string ToString()
    {
        return $"Nome: {Name}\nNascimento: {Birthdate}\nEmail: {Email}";
    }
}
