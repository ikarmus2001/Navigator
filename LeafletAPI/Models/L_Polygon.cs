using MapBuilder_API_Base;

namespace LeafletAPI.Models;

public class L_Polygon : L_StyledObject
{
    public IEnumerable<PointClass> points;

    public L_Polygon(string name, IEnumerable<PointClass> points, MapObjectStyle style)
    {
        this.Name = name.Replace(" ", "_");
        this.points = points;
        this.Style = style;
    }

    internal string ToHtml()
    {
        string parsedPoints = "";
        foreach (var point in points)
        {
            parsedPoints += $"[{point.X}, {point.Y}],";
        }
        parsedPoints.TrimEnd(',');
        
        var html = @$"var {Name} = L.polygon([{parsedPoints}], {Style.Name}).bindTooltip(""{Name.Replace("_", " ")}"", {{ permanent: true, direction: ""center"", className: 'tooltipclass'}}).openTooltip();;";
        return html;
    }
}