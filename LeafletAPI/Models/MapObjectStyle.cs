namespace LeafletAPI.Models;

public class MapObjectStyle
{
    private static int id;
    private static List<MapObjectStyle> instances;

    public string name;
    public string color;
    public string fillColor;
    public float fillOpacity;
    public float weight;
    public float opacity;

    public MapObjectStyle(string name, string color)
    {
        this.name = $"{name}_{id}";
        this.color = color;


        id += 1;

        instances ??= new List<MapObjectStyle>();
        instances.Add(this);
    }

    internal List<MapObjectStyle> GetInstances()
    {
        return instances;
    }

    internal Dictionary<string, string> GetOptionalProperties()
    {
        return new Dictionary<string, string>() 
        {
            {nameof(fillColor), this.fillColor },
            {nameof(fillOpacity), this.fillOpacity.ToString() },
            {nameof(weight), this.weight.ToString() },
            {nameof(opacity), this.opacity.ToString() }
        };
    }

    internal string ToHtml()
    {
        string optionalParameters = "";
        foreach (var optionalPar in this.GetOptionalProperties())
        {
            if(optionalPar.Value != null)
                optionalParameters += $",{optionalPar.Key}: {optionalPar.Value}";
        }

        return $@"var {this.name} = {{
            color: '{this.color}'
            {optionalParameters}
        }};\n";
    }
}