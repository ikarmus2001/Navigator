using LeafletAPI;

namespace SMCEBI_Navigator;

public class PlanDisplay : ContentPage, IQueryAttributable
{
    public PlanDisplay()
	{
        Content = PrepareContent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> mapParameters)
    {
        
    }

    View PrepareContent()
    {
        var floorplanView = new LeafletMap_WebView();
        
        floorplanView = floorplanView.Build();
        //floorplanView.ImportHTML("floorplans.html");

        VerticalStackLayout vsl = new VerticalStackLayout();
        var btn = new Button();
        btn.Text = "Reload";

        btn.Clicked += Btn_Clicked;
        vsl.Children.Add(btn);


        Grid views = new Grid();
        views.RowDefinitions.Add(new RowDefinition(GridLength.Star));
        views.RowDefinitions.Add(new RowDefinition(new GridLength(30)));

        views.Add(floorplanView, 0, 0);
        views.Add(vsl, 0, 1);

        return views;
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        Content = PrepareContent();
    }
}

public class LeafletMap_WebView : WebView
{
    MapBuilder leaf;


    public LeafletMap_WebView(/*string headerVersion= "v1_7_1"*/) 
    {
        leaf = new MapBuilder(/*headerVersion*/);
    }

    public LeafletMap_WebView ImportHTML(string html)
    {
        this.Source = html;
        return this;
    }

    public LeafletMap_WebView Build()
    {
        this.Source = leaf.Build();
        return this;
    }

}