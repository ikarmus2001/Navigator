namespace SMCEBI_Navigator;

public class PlanDisplay : ContentPage, IQueryAttributable
{
    MapConfig mapAttributes;
    public PlanDisplay()
	{
        Content = LoadingScreen();
    }

    private View LoadingScreen()
    {
        return new VerticalStackLayout()
        {
            new Label()
            {
                Text = "Loading",
            }
        };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> mapParameters)
    {
        mapAttributes = (MapConfig)mapParameters[nameof(MapConfig)];
        PrepareContent();
    }

    private void PrepareContent()
    {
        var floorplanView = new LeafletMap_WebView();
        floorplanView.UnparseMap(mapAttributes.ToLeafletMap());
        floorplanView = floorplanView.Build();

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

        Content = views;
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        PrepareContent();
    }
}
