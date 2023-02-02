using Costumer.Domain.Common;

namespace Costumer.Domain.ValueObjects;
public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public string Neighborhood { get; private set; }
    public int Number { get; private set; }
    public string Complement { get; private set; }
    public Address() { }
    public Address(string street, string city, string state, string country, string zipCode, string neighborhood, int number)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        Neighborhood = neighborhood;
        Number = number;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
        yield return Neighborhood;
        yield return Number;
    }
}