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
		var planConfig = new Dictionary<string, object> { { nameof(MapConfig), mapConfig } };

		Shell.Current.GoToAsync(nameof(PlanDisplay), planConfig);
    }

	private void ConfigBtn_Clicked(object sender, EventArgs e)
	{

	}
}