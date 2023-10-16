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
        //fe_SizePicker.ObjBuildingElement = ((VM)BindingContext).EditorElement;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new VM(query);
    }

    private async void SaveChanges()
    {
        ((VM)BindingContext).Save();
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        // TODO: Save changes in Points at Corners property in BuildingElement
    }
}