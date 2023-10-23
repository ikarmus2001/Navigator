using SMCEBI_Navigator.CustomControls;
using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.Views;

public partial class FeatureEditorPage : ContentPage, IQueryAttributable
{
	public FeatureEditorPage()
	{
		InitializeComponent();
	}

    public FeatureEditorPage(Dictionary<string, object> query)
    {
        InitializeComponent();
        BindingContext = new VM(query);
        InvalidateMeasure();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new VM(query);
    }

    // TODO Literally the worst workaround
    private void StylePicker_Loaded(object sender, EventArgs e)
    {
        (sender as StylePicker).IsVisible = ((VM)BindingContext).IsStylePickerVisible;
    }

    private void ChildElements_CC_AddClicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).AddChild();
        this.InvalidateMeasure();
    }
}