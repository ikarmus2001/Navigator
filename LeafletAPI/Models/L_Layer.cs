namespace LeafletAPI.Models
{
    public class L_Layer : L_Object
    {
        public List<L_StyledObject> polygons = new();

        public L_Layer(string name)
        {
            this.Name = name;
        }
    }
}
