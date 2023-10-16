using VM = SMCEBI_Navigator.ViewModels.MapPickerViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
	public MapPickerPage()
	{
        InitializeComponent();
		this.BindingContext = new VM();
        Appearing += MapPickerPage_Appearing;
    }

    private void MapPickerPage_Appearing(object sender, EventArgs e)
    {
        ((VM)BindingContext).UpdateVM();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //((viewModel)BindingContext).Maps[]
    }

    private async void maps_collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedMap = (MapConfig)e.CurrentSelection.FirstOrDefault();
        if (selectedMap == null) return;
        (sender as CollectionView).SelectedItem = null;
        var param = new Dictionary<string, object>() { { nameof(MapConfig), selectedMap } };

        ((VM)BindingContext).SelectMap(Parent as MainNavigationPage, param);
    }

    private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // TODO refactor
        await (Parent as MainNavigationPage).mapDisplay.UpdateDisplay();
    }

    private void ToolbarItem_ShowMap_Clicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).ShowMap(Parent as MainNavigationPage);
    }
}