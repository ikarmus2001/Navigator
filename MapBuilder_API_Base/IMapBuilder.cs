namespace MapBuilder_API_Base;

public interface IMapBuilder
{
    public void AddFeature();

    public void AddFloor(string floorName);

    public void AddRoom(string roomName, IEnumerable<PointClass> roomShape, MapObjectStyle roomStyle, string floorName = "");

    public string Build();
}
