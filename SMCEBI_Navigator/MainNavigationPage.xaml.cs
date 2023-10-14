using SMCEBI_Navigator.Views;

namespace SMCEBI_Navigator;

public partial class MainNavigationPage : NavigationPage
{
	public MapDisplayPage mapDisplay;

	public MainNavigationPage()
	{
		mapDisplay = new();
		InitializeComponent();
		Navigation.PushAsync(new MapPickerPage());

        Loaded += MainNavigationPage_Loaded;
	}

    internal async void ShowMap()
    {
        await Navigation.PushAsync(mapDisplay);
    }

    private async void MainNavigationPage_Loaded(object sender, EventArgs e)
    {
        await mapDisplay.UpdateDisplay();
    }
}