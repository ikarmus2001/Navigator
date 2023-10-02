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
}