using VM = SMCEBI_Navigator.ViewModels.AddFeatureViewModel;

namespace SMCEBI_Navigator.Views;

public partial class AddFeaturePage : ContentPage, IQueryAttributable
{
	public AddFeaturePage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new VM(query);
    }
}