namespace SMCEBI_Navigator;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void MapBtn_Clicked(object sender, EventArgs e)
    {
		var mapConfig = new MapConfig();
		var attributes = new Dictionary<string, object> { { nameof(MapConfig), mapConfig } };

		Shell.Current.GoToAsync(nameof(PlanDisplay), attributes);
    }

	private void ConfigBtn_Clicked(object sender, EventArgs e)
	{

	}
}