using VM = SMCEBI_Navigator.ViewModels.MapPickerViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
	public MapPickerPage()
	{
        InitializeComponent();
		this.BindingContext = new VM();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        //((viewModel)BindingContext).Maps[]
    }

    private void maps_collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedMap = (MapConfig)e.CurrentSelection.FirstOrDefault();
        if (selectedMap == null) return;
        (sender as CollectionView).SelectedItem = null;
        //(sender as CollectionView).Effects
        var param = new Dictionary<string, object>() { {nameof(MapConfig), selectedMap } };
        Shell.Current.GoToAsync(nameof(MapEditorPage), param);
    }

    private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // TODO Update displays asynchronously when switching radios

        //var x = Navigation.NavigationStack.Where(x => x != null).Where(x => x.GetType() == typeof(MapDisplayPage));
        //if (x.Any())
        //    await MapDisplayPage.UpdateDisplay(x.FirstOrDefault() as MapDisplayPage);
    }
}