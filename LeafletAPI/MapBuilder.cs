using LeafletAPI.Models;
using MapBuilder_API_Base;

namespace LeafletAPI;


public partial class MapBuilder : IMapBuilder
{
    private Models.Map map;
    
    private string _htmlHeader = @"<!DOCTYPE html>
<html>
<head>
<meta charset=""utf-8"" />
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">";
    
    private string _htmlBody = "<body>";

    internal L_Polyline buildingShape { get; private set; }

    public MapBuilder()
    {
        map = new Models.Map();
        PrepareStructure();
    }
#region ObjectPreparing

    private void PrepareStructure()
    {
        ComposeHtmlHeader();
    }

    private void ComposeHtmlHeader()
    {
        _htmlHeader += AddStylesheetPath();
        _htmlHeader += AddScriptPath();
        _htmlHeader += AddHeaderStyles();
    }

    private string AddHeaderStyles()
    {
        return """
                <style>
                html, body {
                    height: 100%;
                    margin: 0;
                }

                #map {
                    width: 100%;
                    height: 100%;
                }

                .tooltipclass {
                    background: transparent;
                    border: transparent;
                    box-shadow: 0 0px 0px rgba(0,0,0,0);
                }

                .imgclass {
                    display: block;
                    max-width: 400px;
                    max-height: 400px;
                    width: auto;
                    height: auto;
                }
                </style>
            """;
    }

    private string AddScriptPath()
    {
        return """
            <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
            """;
    }

    private string AddStylesheetPath()
    {
        return """
            <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>
            """;
    }

#endregion

    /// <summary>
    /// Defines outer shape of building, which will be inserted on every level
    /// </summary>
    /// <param name="borders"></param>
    /// <param name="borderStyle">Style of building walls</param>
    public MapBuilder SetBuildingShape(IEnumerable<PointClass> borders, MapObjectStyle borderStyle)
    {
        buildingShape = new L_Polyline("border", borderStyle, borders);
        return this;
    }


    /// <summary>
    /// Creates new map level with provided name.
    /// </summary>
    /// <param name="floorName"></param>
    /// <exception cref="ArgumentException"> if <paramref name="floorName"/> is null or empty</exception>
    public void AddFloor(string floorName)
    {
        if (string.IsNullOrEmpty(floorName))
        {
            throw new ArgumentException($"'{nameof(floorName)}' cannot be null or empty.", nameof(floorName));
        }

        map.layers.Add(new L_Layer(floorName));
    }

    /// <summary>
    /// Creates named room from given shape and associates it with
    /// <paramref name="floorName"/>
    /// </summary>
    /// <param name="roomName"></param>
    /// <param name="roomShape"></param>
    /// <param name="floorName">Optional, last level created before the method call or the one with provided name</param>
    public void AddRoom(string roomName, IEnumerable<PointClass> roomShape, MapObjectStyle roomStyle, string floorName = "")
    {
        if (map.layers.Count < 1)
            throw new InvalidOperationException($"Room cannot be instantiated withouot creating level, call {nameof(AddFloor)}");

        L_Layer roomFloor;
        if (floorName == "")
            roomFloor = map.layers[^1];
        else
            roomFloor = map.layers.Find(layer => layer.Name == floorName);

        if (roomFloor == null) throw new ArgumentException($"Level named {floorName} was not found, did you create it first using {nameof(AddFloor)}?");

        roomFloor.polygons.Add(new L_Polygon(roomName, roomShape, roomStyle));
    }

    public void AddFeature()
    {
        throw new NotImplementedException();
    }

    private void ParseMap()
    {
        _htmlBody += $@"var map = L.map('map', {{crs: L.CRS.Simple,
            minZoom: 0,
            //		cursor: true,
            layers: [{string.Join(", ", map.layers.Select(l => l.NameVariable))}]}});" + Environment.NewLine;

        _htmlBody += $"map.setView([25.25, 9], 4);" + Environment.NewLine;
        _htmlBody += "L.control.layers(mapLevels, null, {collapsed:false}).addTo(map);" + Environment.NewLine;
    }



    #region Build
    public string Build()
    {
        if (map.layers.Count == 0) throw new InvalidOperationException($"Map cannot be built without any levels nor rooms, call {nameof(AddFloor)} and {nameof(AddRoom)}");
        else if (map.layers.FirstOrDefault().polygons.Count == 0) throw new InvalidOperationException($"Map cannot be built without any rooms, call {nameof(AddRoom)}");

        PrepareMapVariable();
        _htmlBody += "<script>"; // Open script tag
        ParseStyles();
        ParsePolylines();
        ParsePolygons();
        ParseLayers();
        ParseMap();
        _htmlBody += "</script>"; // Close script tag

        return _htmlHeader + "</head>" + _htmlBody + "</body></html>";
    }

    private void PrepareMapVariable() => _htmlBody += "<div id=\"map\"></div>";

    private void ParseStyles()
    {
        List<MapObjectStyle> createdStyles = MapObjectStyle.GetInstances();

        string htmlStyles = "";

        foreach (MapObjectStyle uniqueStyle in createdStyles)
        {
            htmlStyles += uniqueStyle.ToHtmlDefinition() + Environment.NewLine;
        }

        _htmlBody += htmlStyles;
    }

    private void ParsePolylines()
    {
        _htmlBody += buildingShape.ToHtml() + Environment.NewLine;
        // TODO: add polyline parsing for level shapes, rooms, marked features
    }

    private void ParseLayers()
    {
        foreach (L_Layer l in map.layers)
        {
            _htmlBody += l.ToHtml() + Environment.NewLine;
        }

        string mapLvls = "var mapLevels = {";
        foreach (L_Layer l in map.layers)
        {
             mapLvls += $"'{l.Name}': {l.NameVariable},";
        }
        _htmlBody += mapLvls.TrimEnd(',') + "};" + Environment.NewLine;
    }
    
    private void ParsePolygons()
    {
        string parsedPolygons = "";

        foreach (L_Layer l in map.layers)
        {
            foreach (L_Polygon p in l.polygons)
            {
                parsedPolygons += p.ToHtml() + Environment.NewLine;
            }
        }

        _htmlBody += parsedPolygons;
    }
    #endregion
}