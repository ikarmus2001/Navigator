using LeafletAPI;
using MapBuilder_API_Base;
using SMCEBI_Navigator.Models;
using System.Globalization;

namespace SMCEBI_Navigator;

internal static class ConfigParser
{
    internal static async Task<IMapBuilder> ParseToApi(MapConfig config)
    {
        IMapBuilder result;
        if (config.Engine == MapEngine.Leaflet)
            result = await ParseToLeaflet(config);
        else
            throw new NotImplementedException();

        return result;
    }

    private static async Task<LeafletAPI.MapBuilder> ParseToLeaflet(MapConfig config)
    {
        MapBuilder builder = new();
        builder.SetBuildingShape(config.Building.Corners, config.Building.Style.ToLeafletApi());

        foreach (var floor in config.Building.Floors)
        {
            builder.AddFloor(floor.Name);

            foreach (var room in floor.Rooms)
            {
                builder.AddRoom(room.Name, room.Corners, room.Style.ToLeafletApi());
            }
        }

        return builder;
    }

    internal static MapObjectStyle ToLeafletApi(this ElementStyle style)
    {
        var parsed = new MapObjectStyle(style.Name, style.LineColor)
        {
            Opacity = float.Parse(style.LineOpacity ?? "1", CultureInfo.InvariantCulture.NumberFormat),
            Weight = float.Parse(style.LineWidth ?? "0", CultureInfo.InvariantCulture.NumberFormat),
            FillColor = style.FillColor ?? "",
            FillOpacity = float.Parse(style.FillOpacity ?? "1", CultureInfo.InvariantCulture.NumberFormat)
        };

        return parsed;
    }
}
