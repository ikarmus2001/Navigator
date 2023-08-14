namespace LeafletAPI.Models
{
    public class L_Polyline : L_StyledObject
    {
        private static int id;
        public Dictionary<string, float[,]> points;

        public L_Polyline(string name, MapObjectStyle borderStyle, Dictionary<string, float[,]> points)
        {
            this.Name = $"{name}_{id}";
            Style = borderStyle;
            this.points = points;
        }
    }
}