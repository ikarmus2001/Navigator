namespace MapBuilder_API_Base;

public class MapObjectStyle
{
    private static int id;
    internal static List<MapObjectStyle> instances { get; private set; }

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

    public static List<MapObjectStyle> GetInstances() => instances;
}