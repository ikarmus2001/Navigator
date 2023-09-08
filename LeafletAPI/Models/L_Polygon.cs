namespace LeafletAPI.Models
{
    public class L_Polygon : L_StyledObject
    {
        public float[,] points;

        public L_Polygon(string name, float[,] points, MapObjectStyle style)
        {
            this.Name = name;
            this.points = points;
            this.Style = style;
        }
    }
}