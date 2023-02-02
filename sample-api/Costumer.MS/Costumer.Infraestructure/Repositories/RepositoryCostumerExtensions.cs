using System.Reflection;
using System.Text;
using Costumer.Domain.Entities;

namespace Costumer.Infraestructure.Repositories;

public static class RepositoryCostumerExtensions
{
    public static IQueryable<Person> FilterCostumer(this IQueryable<Person>
                                                            costumer, uint maxId, uint minId) =>
                                                                costumer.Where(e => e.Id >= maxId && e.Id <= minId);

    public static IQueryable<Person> Search(this IQueryable<Person> costumer,
                                                    string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return costumer;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return costumer.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
    }
}
