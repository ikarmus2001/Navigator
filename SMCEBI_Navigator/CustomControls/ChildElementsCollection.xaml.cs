using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using FA = SMCEBI_Navigator.ViewModels.FeatureAction;
using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.CustomControls;

public partial class ChildElementsCollection : ContentView
{
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            propertyName: nameof(Items),
            returnType: typeof(IEnumerable<BuildingElement>),
            declaringType: typeof(SizePicker),
            defaultValue: new List<BuildingElement>(),
            defaultBindingMode: BindingMode.TwoWay);

    public IEnumerable<BuildingElement> Items
    {
        get => (IEnumerable<BuildingElement>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public event EventHandler AddClicked;

    public ChildElementsCollection()
	{
		InitializeComponent();
        Loaded += ChildElementsCollection_Loaded;
	}

    private void ChildElementsCollection_Loaded(object sender, EventArgs e)
    {
        Children_CollectionView.ItemsSource = Items;
    }

    private async void CollectionView_SelectionChanged(object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var param = new Dictionary<string, object>() { 
			{ nameof(Building), (Parent.BindingContext as VM).buildingRef },
			{ nameof(BuildingElement), e.CurrentSelection.Single()},
            { nameof(FA), FA.Modify }
        };
        await Navigation.PushAsync(new FeatureEditorPage(param));
        (sender as CollectionView).SelectedItem = null;
    }

    private void AddFloorBtn_Clicked(object sender, EventArgs e)
    {
        AddClicked?.Invoke(this, EventArgs.Empty);
    }
}