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
    }
}