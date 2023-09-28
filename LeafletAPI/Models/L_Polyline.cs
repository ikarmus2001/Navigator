namespace LeafletAPI.Models;

internal class L_Polyline : L_StyledObject
{
    private static int id = 0;
    internal List<Point> points;

    internal L_Polyline(string name, MapObjectStyle style, List<Point> points)
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
            parsedObjectShape += $"[{p}],\n";
        }

        var parsedHTML = $@"var {Name} = L.polyline(
[
    {parsedObjectShape}
], {Style.Name});";

        return parsedHTML;
    }
}