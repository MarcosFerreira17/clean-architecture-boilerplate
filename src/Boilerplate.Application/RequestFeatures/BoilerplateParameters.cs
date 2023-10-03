namespace Boilerplate.Application.RequestFeatures;

/// <summary>
/// Here you can apply all parameters for filtering your entity, the actual implementation it' is just a example;
/// </summary>
public class BoilerplateParameters : RequestParameters
{
    public BoilerplateParameters()
    {
        OrderBy = "name";
    }
    public uint MinId { get; set; }
    public uint MaxId { get; set; } = int.MaxValue;
    public bool ValidIdRange => MaxId > MinId;
    public string SearchTerm { get; set; }
}