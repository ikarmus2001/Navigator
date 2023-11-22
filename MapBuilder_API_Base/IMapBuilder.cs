namespace MapBuilder_API_Base;

public interface IMapBuilder
{
    public void AddFeature();

    public void AddFloor();

    public void AddRoom();

    public string Build();
}
