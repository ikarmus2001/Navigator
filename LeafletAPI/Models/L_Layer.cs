namespace LeafletAPI.Models;

public class L_Layer : L_Object
{
    public List<L_Polygon> polygons = new();

    public L_Layer(string name)
    {
        this.Name = name.Replace(" ", "_");
    }

    internal string ToHtml()
    {
        var html = @$"var {Name} = L.layerGroup([{string.Join(", ", polygons.Select(p => p.Name))}]);";
        return html;
    }
}
