using Boilerplate.Domain.Entities;

namespace Boilerplate.Infra.Database.Repositories;

public static class QueryExtensions
{
    public static IQueryable<BoilerplateEntity> FilterBoilerplate(this IQueryable<BoilerplateEntity>
                                                            Boilerplate, uint maxId, uint minId) =>
                                                                Boilerplate.Where(e => e.Id >= maxId && e.Id <= minId);

    public static IQueryable<BoilerplateEntity> Search(this IQueryable<BoilerplateEntity> Boilerplate,
                                                    string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Boilerplate;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return Boilerplate.Where(e => e.ExampleString.ToLower().Contains(lowerCaseTerm));
    }
}
