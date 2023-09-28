using MapBuilder_API_Base;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator;


internal sealed class MapConfig
{
    public int HtmlChangeId { get; set; }
    public int ObjChangeId { get; set; }
    public Tuple<uint, string> VersionedCachedHtml { get; set; }
    internal MapEngine Engine { get; set; }
    public Tuple<uint, uint> MapSize { get; set; }
    public Building Building { get; set; }

    public MapConfig()
    {
        Building = new Building();
    }

    ///<summary>
    ///Gets newest html from versionedCachedHtml, if it's not up to date, updates it via Build method
    ///</summary>
    internal async Task<WebView> GetView()
    {
        IMapBuilder builder = await ConfigParser.ParseToApi(this);
        return new WebView()
        {
            Source = builder.Build()
        };
    }
}