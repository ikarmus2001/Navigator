using System.Diagnostics;
using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.Views;

public partial class FeatureEditorPage : ContentPage
{
    public FeatureEditorPage(Dictionary<string, object> query)
    {
        InitializeComponent();
        BindingContext = new VM(query, Navigation);
        Loaded += FeatureEditorPage_Loaded;
        InvalidateMeasure();
    }

    private void FeatureEditorPage_Loaded(object sender, EventArgs e)
    {
        StylePicker_CC.IsVisible = ((VM)BindingContext).IsStylePickerVisible;
        SizePicker_CC.IsVisible = ((VM)BindingContext).IsSizePickerVisible;
        ElementPreview_CC.IsVisible = ((VM)BindingContext).IsPreviewVisible;
    }

    private void ChildElements_CC_AddClicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).AddChild();
    }

    private void Features_CC_AddClicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).AddFeature();
    }

    private async void ChildElements_CC_ItemSelected(object sender, CustomControls.SelectedBuildingElementEventArgs e) => await ((VM)BindingContext).GoToEditor(e.BuildingElement);

    private async void FeaturesChildren_CC_ItemSelected(object sender, CustomControls.SelectedBuildingElementEventArgs e) => await ((VM)BindingContext).GoToEditor(e.BuildingElement);

    private void Debug_ToolbarItem_Clicked(object sender, EventArgs e)
    {
        
    }
}