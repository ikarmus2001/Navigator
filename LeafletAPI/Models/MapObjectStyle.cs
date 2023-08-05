namespace LeafletAPI.Models
{
    public class MapObjectStyle
    {
        public string color;
        public string fillColor;
        public float fillOpacity;
        public float weight;
        public float opacity;

        public MapObjectStyle(string color) 
        {
            this.color = color;
        }
    }
}