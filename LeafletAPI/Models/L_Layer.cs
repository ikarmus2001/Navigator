namespace LeafletAPI.Models;

public class L_Layer : L_Object
{
    public List<L_Polygon> polygons = new();

    public string NameVariable { get => Name.Replace(" ", "_"); }

    public L_Layer(string name)
    {
        this.Name = name;
    }

    internal string ToHtml()
    {
        var html = @$"var {NameVariable} = L.layerGroup([{string.Join(", ", polygons.Select(p => p.Name))}]);";
        return html;
    }
}
