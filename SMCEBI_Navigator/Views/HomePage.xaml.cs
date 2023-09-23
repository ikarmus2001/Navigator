namespace SMCEBI_Navigator.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void MapBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MapDisplayPage));
    }

    private void ConfigBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MapPickerPage));
    }
}