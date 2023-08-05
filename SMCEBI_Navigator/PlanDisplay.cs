namespace SMCEBI_Navigator;

public class PlanDisplay : ContentPage
{
	public PlanDisplay()
	{
        Content = PrepareContent();
    }

    View PrepareContent()
    {
        Grid views = new Grid();

        var floorplanView = LeafletMap_WebView.Create()
        {
            Source = "floorplans.html",
            MinimumHeightRequest = 200,
        };

        VerticalStackLayout vsl = new VerticalStackLayout();
        var btn = new Button();
        btn.Text = "cokolwieeeeeeek";
        
        //btn.Clicked += 
        vsl.Children.Add(btn);

        views.RowDefinitions.Add(new RowDefinition(GridLength.Star));
        views.RowDefinitions.Add(new RowDefinition(new GridLength(30)));

        views.Add(floorplanView, 0, 0);
        views.Add(vsl, 0, 1);

        return views;
    }
}

public class LeafletMap_WebView : WebView
{
    public LeafletMap_WebView() { }



}