using Template.Domain.Entities;

namespace Template.Infrastructure.Repositories;

public static class QueryExtensions
{
    public static IQueryable<TemplateEntity> FilterTemplate(this IQueryable<TemplateEntity>
                                                            template, uint maxId, uint minId) =>
                                                                template.Where(e => e.Id >= maxId && e.Id <= minId);

    public static IQueryable<TemplateEntity> Search(this IQueryable<TemplateEntity> template,
                                                    string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return template;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return template.Where(e => e.ExampleString.ToLower().Contains(lowerCaseTerm));
    }
}
