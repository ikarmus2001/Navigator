using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.CustomControls;

public partial class ChildElementsCollection : ContentView
{
    public event EventHandler AddClicked;

    public ChildElementsCollection()
	{
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var param = new Dictionary<string, object>() { 
			{ nameof(Building), (Parent.BindingContext as VM).buildingRef },
			{ nameof(BuildingElement), e.CurrentSelection.Single() as BuildingElement },
			//{ nameof(FeatureAction), FeatureAction.Edit }
		};
        await Navigation.PushAsync(new FeatureEditorPage(param));
        (sender as CollectionView).SelectedItem = null;
    }

    private void AddFloorBtn_Clicked(object sender, EventArgs e)
    {
        AddClicked?.Invoke(this, EventArgs.Empty);
    }
}