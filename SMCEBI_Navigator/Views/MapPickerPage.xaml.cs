using FA = SMCEBI_Navigator.ViewModels.FeatureAction;
using VM = SMCEBI_Navigator.ViewModels.MapPickerViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
    MapConfig EditedMap = null;

	public MapPickerPage()
	{
        InitializeComponent();
        Appearing += MapPickerPage_Appearing;
        Loaded += MapPickerPage_Loaded;
        NavigatedTo += MapPickerPage_NavigatedToAsync;
    }

    private async void MapPickerPage_NavigatedToAsync(object sender, NavigatedToEventArgs e)
    {
        if (EditedMap != null)
        {
            ((VM)BindingContext).UpdateVM();
            await FileManager.SaveMap(EditedMap);
        }
        EditedMap = null;
    }

    private void MapPickerPage_Appearing(object sender, EventArgs e)
    {
        BindingContext ??= new VM(Navigation);
    }

    private void MapPickerPage_Loaded(object sender, EventArgs e)
    {
        ((VM)BindingContext).UpdateVM();
    }

    private async void Maps_collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        EditedMap = e.CurrentSelection.Single() as MapConfig;
        (sender as CollectionView).SelectedItem = null;

        await ((VM)BindingContext).GoToEditor(EditedMap.Building, FA.Modify);
    }

    private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        await (Parent as MainNavigationPage).mapDisplay.UpdateDisplay();
    }

    private void ToolbarItem_ShowMap_Clicked(object sender, EventArgs e)
    {
        VM.ShowMap(Parent as MainNavigationPage);
    }

    private async void ToolbarItem_AddMap_Clicked(object sender, EventArgs e)
    {
        EditedMap = new MapConfig();
        _ = MapStorage.configs.Append(EditedMap);
        await ((VM)BindingContext).GoToEditor(EditedMap.Building, FA.Add);
    }
}