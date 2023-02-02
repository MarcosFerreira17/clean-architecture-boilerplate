namespace Costumer.Domain.Dtos;
public record ListPersonDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
}
