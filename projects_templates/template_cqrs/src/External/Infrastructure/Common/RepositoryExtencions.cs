using Domain.Entities;

namespace Infrastructure.Common;
public static class RepositoryExtencions
{
    public static IQueryable<Entity> FilterTemplate(this IQueryable<Entity>
                                                    template, uint maxId, uint minId) =>
                                                        template.Where(e => e.Id >= maxId && e.Id <= minId);

    public static IQueryable<Entity> Search(this IQueryable<Entity> template,
                                                    string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return template;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return template.Where(e => e.Example.ToLower().Contains(lowerCaseTerm));
    }
}
