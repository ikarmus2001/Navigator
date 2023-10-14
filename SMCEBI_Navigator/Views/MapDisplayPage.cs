namespace SMCEBI_Navigator.Views;

public partial class MapDisplayPage : ContentPage
{
    public MapDisplayPage()
    {
        //WebView webView = storage.Current.GetView();
        //Loaded += async (s, e) => { await PrepareContent(); };
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

    private async Task PrepareContent()
    {
        VerticalStackLayout vsl = new();
        var btn = new Button();
        btn.Text = "Reload";

        btn.Clicked += Btn_Clicked;
        vsl.Children.Add(btn);


        Grid views = new Grid();
        views.RowDefinitions.Add(new RowDefinition(GridLength.Star));
        views.RowDefinitions.Add(new RowDefinition(new GridLength(30)));

        IView x = await MapStorage.Current.GetView();
        views.Add(vsl, 0, 1);
        views.Add(x, 0, 0);

        Content = views;
    }

    internal async Task UpdateDisplay()
    {
        await PrepareContent();
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        //PrepareContent();
    }
}
