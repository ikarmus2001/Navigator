using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.CustomControls;

public partial class FeatureCollection : ContentView
{
	public FeatureCollection()
	{
		InitializeComponent();
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var param = new Dictionary<string, object>() {
            { nameof(Building), (Parent.BindingContext as VM).buildingRef },
            { nameof(BuildingElement), e.CurrentSelection.Single() as BuildingElement },
			//{ nameof(FeatureAction), FeatureAction.Edit },
			{ nameof(Type), e.CurrentSelection.GetType() }
        };
        Navigation.PushAsync(new FeatureEditorPage(param));
        (sender as CollectionView).SelectedItem = null;
    }
}