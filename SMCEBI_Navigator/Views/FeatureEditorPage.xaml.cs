using VM = SMCEBI_Navigator.ViewModels.FeatureEditorViewModel;

namespace SMCEBI_Navigator.Views;

public partial class FeatureEditorPage : ContentPage, IQueryAttributable
{
	public FeatureEditorPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new VM(query);
    }

    private async void SaveChanges()
    {
        ((VM)BindingContext).Save();
    }
}