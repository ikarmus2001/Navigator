namespace SMCEBI_Navigator.Views;

public partial class MapDisplayPage : ContentPage
{
    private IView mapView;
    public MapDisplayPage()
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
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            }
        };
    }

    private async Task PrepareContent(string injectedHtml=null)
    {
        var btn = new Button
        {
            Text = "Reload"
        };
        btn.Clicked += Btn_Clicked;

        Editor injectHtmlEditor = new();
        injectHtmlEditor.Completed += InjectHtmlEditor_Accepted;

        VerticalStackLayout vsl = new()
        {
            Children =
            {
                btn,
                injectHtmlEditor
            }
        };

        Grid gridView = new()
        {
            RowDefinitions = new()
            {
                new RowDefinition(GridLength.Star),
                new RowDefinition(new GridLength(100))
            }
        };

        if (string.IsNullOrEmpty(injectedHtml) && MapStorage.Current != null)
            mapView = await MapStorage.Current.GetView();
        else
            mapView = new WebView() { Source = new HtmlWebViewSource() { Html = injectedHtml } };
        

        gridView.Add(vsl, 0, 1);
        gridView.Add(mapView, 0, 0);

        Content = gridView;
    }

    internal async Task UpdateDisplay()
    {
        await PrepareContent();
    }

    private async void InjectHtmlEditor_Accepted(object sender, EventArgs e)
    {
        var x = sender as Editor;
        await PrepareContent(x.Text);
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        var Html = ((mapView as WebView).Source as HtmlWebViewSource).Html;
        Clipboard.SetTextAsync(Html);
    }
}
