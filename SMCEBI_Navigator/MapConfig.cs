﻿using MapBuilder_API_Base;
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

    // Should be refactored, to avoid reversed dependency
    public bool IsSelected { get { return MapStorage.IsSelected(this); } set { if (value == true) MapStorage.SelectMap(this); }  }

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
        var x = new WebView()
        {
            Source = new HtmlWebViewSource() { Html = builder.Build() }
        };

        return x;
    }
}