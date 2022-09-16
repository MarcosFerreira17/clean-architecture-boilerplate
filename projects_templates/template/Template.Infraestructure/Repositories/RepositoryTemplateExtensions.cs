using System.Reflection;
using System.Text;
using Template.Domain.Entities;

namespace Template.Infraestructure.Repositories;

public static class RepositoryTemplateExtensions
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

    // public static IQueryable<TemplateEntity> Sort(this IQueryable<TemplateEntity> template,
    //                                                 string orderByQueryString)
    // {
    //     if (string.IsNullOrWhiteSpace(orderByQueryString))
    //         return template.OrderBy(e => e.ExampleString);

    //     var orderParams = orderByQueryString.Trim().Split(',');
    //     var propertyInfos = typeof(TemplateEntity)
    //         .GetProperties(BindingFlags.Public | BindingFlags.Instance);
    //     var orderQueryBuilder = new StringBuilder();

    //     foreach (var param in orderParams)
    //     {
    //         if (string.IsNullOrWhiteSpace(param)) continue;

    //         var propertyFromQueryName = param.Split(" ")[0];

    //         var objectProperty = Array.Find(propertyInfos, pi =>
    //             pi.Name.Equals(
    //                 propertyFromQueryName,
    //                 StringComparison.InvariantCultureIgnoreCase));

    //         if (objectProperty == null) continue;

    //         var direction = param.EndsWith(" desc") ? "descending" : "ascending";
    //         orderQueryBuilder.Append(objectProperty.Name).Append(' ').Append(direction).Append(", ");
    //     }

    //     var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

    //     if (string.IsNullOrWhiteSpace(orderQuery))
    //         return template.OrderBy(e => e.ExampleString);

    //     return template.OrderBy(orderQuery);
    // }
}
