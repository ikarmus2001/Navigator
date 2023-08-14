namespace LeafletAPI.Models
{
    public class MapObjectStyle
    {
        private static int id;
        public string name;
        public string color;
        public string fillColor;
        public float fillOpacity;
        public float weight;
        public float opacity;

        public MapObjectStyle(string name, string color)
        {
            this.name = $"{name}_{id}";
            this.color = color;
        }
    }
}