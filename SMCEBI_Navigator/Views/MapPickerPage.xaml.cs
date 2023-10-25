using SMCEBI_Navigator.Models;
using VM = SMCEBI_Navigator.ViewModels.MapPickerViewModel;
using FA = SMCEBI_Navigator.ViewModels.FeatureAction;

namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
	public MapPickerPage()
	{
        InitializeComponent();
        Appearing += MapPickerPage_Appearing;
        Loaded += MapPickerPage_Loaded;
    }

    private void MapPickerPage_Appearing(object sender, EventArgs e)
    {
        BindingContext ??= new VM();
    }

    private void MapPickerPage_Loaded(object sender, EventArgs e)
    {
        ((VM)BindingContext).UpdateVM();
    }

    private async void Maps_collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var selectedMap = e.CurrentSelection.Single() as MapConfig;
        var param = new Dictionary<string, object>() {
            { nameof(Building), selectedMap.Building },
            { nameof(BuildingElement), selectedMap.Building},
            { nameof(FA), FA.Modify }
        };

        (sender as CollectionView).SelectedItem = null;

        await Navigation.PushAsync(new FeatureEditorPage(param));
    }

    private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        await (Parent as MainNavigationPage).mapDisplay.UpdateDisplay();
    }

    private void ToolbarItem_ShowMap_Clicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).ShowMap(Parent as MainNavigationPage);
    }
}