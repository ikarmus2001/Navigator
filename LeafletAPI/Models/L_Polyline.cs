using MapBuilder_API_Base;

namespace LeafletAPI.Models;

internal class L_Polyline : L_StyledObject
{
    private static int id = 0;
    internal IEnumerable<PointClass> points;

    internal L_Polyline(string name, MapObjectStyle style, IEnumerable<PointClass> points)
    {
        this.Name = $"{name}_{id}";
        Style = style;
        this.points = points;

        id += 1;
    }

    internal string ToHtml()
    {
        string parsedObjectShape = "";
        foreach (var p in points)
        {
            parsedObjectShape += $"[{p.X}, {p.Y}]," + Environment.NewLine;
        }

        var parsedHTML = $@"var {Name} = L.polyline(
[
    {parsedObjectShape}
], {Style.Name});";

        return parsedHTML;
    }
}