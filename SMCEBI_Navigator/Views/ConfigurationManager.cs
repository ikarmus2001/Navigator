namespace SMCEBI_Navigator.Views;

public class ConfigurationManager : ContentPage
{
    public ConfigurationManager()
    {
        Content = PrepareContent();
    }

    private View PrepareContent()
    {
        

        var saveBtn = new Button()
        {
            Text = "Save"
        };

        saveBtn.Clicked += (s, e) => SaveClicked();


        return new VerticalStackLayout()
        {
            
            saveBtn,
        };
    }

    private void SaveClicked()
    {
        throw new NotImplementedException();
    }
}