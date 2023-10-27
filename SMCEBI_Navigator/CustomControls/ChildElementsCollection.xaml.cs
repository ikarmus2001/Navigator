using Microsoft.Maui.Controls;
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
            declaringType: typeof(ChildElementsCollection),
            defaultValue: new List<BuildingElement>(),
            defaultBindingMode: BindingMode.TwoWay);

    public IEnumerable<BuildingElement> Items
    {
        get => (IEnumerable<BuildingElement>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public static readonly BindableProperty ChildName_TooltipProperty = BindableProperty.Create(
        propertyName: nameof(ChildName_Tooltip),
        returnType: typeof(string),
        declaringType: typeof(ChildElementsCollection),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneTime);

#nullable enable
    public string? ChildName_Tooltip
    {
        get => (string)GetValue(ChildName_TooltipProperty);
        set => SetValue(ChildName_TooltipProperty, value);
    }
#nullable disable

    public event EventHandler AddClicked;

    public ChildElementsCollection()
    {
        InitializeComponent();
        Loaded += ChildElementsCollection_Loaded;
    }

    private void ChildElementsCollection_Loaded(object sender, EventArgs e)
    {
        Children_CollectionView.ItemsSource = Items;
        ToolTipProperties.SetText(AddFloorBtn, "Add " + ChildName_Tooltip);
        InvalidateLayout();
    }

    private async void CollectionView_SelectionChanged(object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        (sender as CollectionView).SelectedItem = null;
        await VM.GoToEditor((Parent.BindingContext as VM).buildingRef, (BuildingElement)e.CurrentSelection.Single(), FA.Modify, Navigation);
    }

    private void AddFloorBtn_Clicked(object sender, EventArgs e)
    {
        AddClicked?.Invoke(this, EventArgs.Empty);
    }
}