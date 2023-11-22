namespace LeafletAPI.Models;

public class Map
{
    public List<L_Layer> layers;

    public Map()
    {
        layers = new();
    }
}
