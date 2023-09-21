namespace LeafletAPI.Models
{
    internal class L_Polyline : L_StyledObject
    {
        private static int id = 0;
        internal Dictionary<string, float[,]> points;

        internal L_Polyline(string name, MapObjectStyle style, Dictionary<string, float[,]> points)
        {
            this.Name = $"{name}_{id}";
            Style = style;
            this.points = points;

            id += 1;
        }

        internal string ToHtml()
        {
            string parsedObjectShape = "";
            foreach (var point in points) 
            {
                parsedObjectShape += $" //{point.Key} \n" +
                    $"[{point.Value}],";
            }
            

            var parsedHTML = $@"var {Name} = L.polyline(
[
    {parsedObjectShape}
], {Style.name});";

            return parsedHTML;
        }
    }
}