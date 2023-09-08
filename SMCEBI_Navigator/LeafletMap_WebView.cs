using LeafletAPI;

namespace SMCEBI_Navigator;

public class LeafletMap_WebView : WebView
{
    MapBuilder leaf;


    public LeafletMap_WebView()
    {
        leaf = new MapBuilder();
    }

    public LeafletMap_WebView ImportHTML(string html)
    {
        this.Source = html;
        return this;
    }

    internal void UnparseMap()
    {
        //MapConfig.Buil
    }

    public LeafletMap_WebView Build()
    {
        this.Source = leaf.Build();
        return this;
    }
}