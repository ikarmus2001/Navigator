namespace LeafletAPI.Models;

public class MapObjectStyle
{
    private static int id;
    private static List<MapObjectStyle> instances;

    public string Name;
    /// <summary>
    /// Color of lines / borders
    /// </summary>
    public string Color;
#nullable enable
    public float? Opacity;
    public float? Weight;
    public string? FillColor;
    public float? FillOpacity;
#nullable disable

    public MapObjectStyle(string name, string color)
    {
        this.Name = $"{name}_{id}";
        this.Color = color;


        id += 1;

        instances ??= new List<MapObjectStyle>();
        instances.Add(this);
    }

    internal List<MapObjectStyle> GetInstances()
    {
        return instances;
    }
#nullable enable
    internal Dictionary<string, string?> GetOptionalProperties()
    {
        return new Dictionary<string, string?>() 
        {
            {nameof(FillColor), this.FillColor },
            {nameof(FillOpacity), this.FillOpacity.ToString() },
            {nameof(Weight), this.Weight.ToString() },
            {nameof(Opacity), this.Opacity.ToString() }
        };
    }

    internal string ToHtmlDefinition()
    {
        string optionalParameters = "";
        foreach (var optionalPar in this.GetOptionalProperties())
        {
            if(!string.IsNullOrEmpty(optionalPar.Value))
                optionalParameters += $",{optionalPar.Key}: {optionalPar.Value}";
        }

        return $@"var {this.Name} = {{
            color: '{this.Color}'
            {optionalParameters}
        }};\n";
    }
#nullable disable
}