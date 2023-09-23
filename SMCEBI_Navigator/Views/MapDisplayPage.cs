namespace SMCEBI_Navigator.Views;

public partial class MapDisplayPage : ContentPage
{
    MapConfig mapConfig;

    public MapDisplayPage()
    {
        //WebView webView = storage.Current.GetView();
        //Loaded += (s, e) => { PrepareContent(webView); };
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

    private void PrepareContent(WebView injectedWebView)
    {
        VerticalStackLayout vsl = new();
        var btn = new Button();
        btn.Text = "Reload";

        btn.Clicked += Btn_Clicked;
        vsl.Children.Add(btn);


        Grid views = new Grid();
        views.RowDefinitions.Add(new RowDefinition(GridLength.Star));
        views.RowDefinitions.Add(new RowDefinition(new GridLength(30)));

        views.Add(injectedWebView, 0, 0);
        views.Add(vsl, 0, 1);

        Content = views;

    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        //PrepareContent();
    }
}
