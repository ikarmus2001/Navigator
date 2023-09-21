using LeafletAPI;
using SMCEBI_Navigator.Models;
using System.Text;
using System.Text.Json;

namespace SMCEBI_Navigator;


internal sealed class MapConfig
{
    public int HtmlChangeId { get; set; }
    public int ObjChangeId { get; set; }
    public Tuple<uint, string> VersionedCachedHtml { get; set; }
    internal MapEngine Engine { get; set; }
    public Tuple<uint, uint> MapSize { get; set; }
    public Building Building { get; set; }

    public MapConfig() { }

    //public MapConfig(MapEngine engine = MapEngine.Leaflet)
    //{
    //    building = new Building();
    //    this.engine = engine;
    //}

    //private MapConfig(Building unparsedBuilding, MapEngine engine = MapEngine.Leaflet)
    //{
    //    building = unparsedBuilding;
    //    this.engine = engine;
    //}

    //public static async Task<MapConfig> CreateNew(string buildingJson, MapEngine engine = MapEngine.Leaflet)
    //{
    //    return await CreateNew(new MemoryStream(Encoding.UTF8.GetBytes(buildingJson)), engine);
    //}

    //public static async Task<MapConfig> CreateNew(Stream buildingStream, MapEngine engine = MapEngine.Leaflet)
    //{
    //    var unparsed = await UnparseJsonBuildingAsync(buildingStream);
    //    return new MapConfig(unparsed, engine);
    //}

    //private static async Task<Building> UnparseJsonBuildingAsync(Stream inputJson)
    //{
    //    if (inputJson == null || inputJson.Length < 1)
    //        throw new ArgumentException("Json can't be empty");

    //    return await JsonSerializer.DeserializeAsync<Building>(inputJson);
    //}

    //internal void AddFloor()
    //{

    //}

    //internal void AddRoom()
    //{

    //}



    // <summary>
    // Gets newest html from versionedCachedHtml, if it's not up to date, updates it via Build method
    // </summary>
    //internal WebView GetView()
    //{
    //    //new MapBuilder(building.ParseToApi<engine>());
    //}
}