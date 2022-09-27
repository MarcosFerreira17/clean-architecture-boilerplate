namespace Application.RequestFeatures;

/// <summary>
/// Here you can apply all parameters for filtering your entity, the actual implementation it' is just a example;
/// </summary>
public class TemplateParameters : RequestParameters
{
    public uint MinId { get; set; }
    public uint MaxId { get; set; } = int.MaxValue;
    public bool ValidIdRange => MaxId > MinId;
    public string SearchTerm { get; set; }
}