using viewModel = SMCEBI_Navigator.ViewModels.MapPickerViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
	public MapPickerPage()
	{
        InitializeComponent();
		this.BindingContext = new viewModel();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        //((viewModel)BindingContext).Maps[]
    }
}