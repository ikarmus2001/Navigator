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

    public MainNavigationPage(Page page)
    {
        mapDisplay = new();
        InitializeComponent();
        Navigation.PushAsync(page);

        Loaded += MainNavigationPage_Loaded;
    }

    internal async void ShowEditor(Dictionary<string, object> query)
    {
        await Navigation.PushAsync(new MainNavigationPage(new MapEditorPage(query)));
    }

    internal async void ShowMap()
    {
        await Navigation.PushAsync(mapDisplay);
    }

    private async void MainNavigationPage_Loaded(object sender, EventArgs e)
    {
        this.Window.MinimumWidth = 1000;
        await mapDisplay.UpdateDisplay();
    }
}