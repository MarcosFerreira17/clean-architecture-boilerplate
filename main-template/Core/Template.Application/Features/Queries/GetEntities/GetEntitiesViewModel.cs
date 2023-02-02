namespace Template.Application.Features.Queries.GetEntities;

public class GetEntitiesViewModel
{
    public GetEntitiesViewModel(long id, string example)
    {
        Id = id;
        Example = example;
    }

    public long Id { get; set; }
    public string Example { get; set; }
}
