using LeafletAPI;

namespace SMCEBI_Navigator;

public class PlanDisplay : ContentPage
{
	public PlanDisplay()
	{
        Content = PrepareContent();
    }

    View PrepareContent()
    {
        var floorplanView = new LeafletMap_WebView();
        floorplanView.ImportHTML("floorplans.html");
        //floorplanView.Build();

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
    LeafletAPI leaf;


    public LeafletMap_WebView(string headerVersion= "v1_7_1") 
    {
        leaf = new LeafletAPI(headerVersion);
    }

    public LeafletMap_WebView ImportHTML(string html)
    {
        this.Source = html;
        return this;
    }

    public LeafletMap_WebView Build()
    {
        this.Source = leaf.Build();
        throw new NotImplementedException();
    }

}