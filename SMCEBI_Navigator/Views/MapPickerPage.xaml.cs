namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
    public MapPickerPage()
    {
        InitializeComponent();
        BindingContext = MapStorage.configs;
    }



    private void CreateNewMapButton_Clicked(object sender, EventArgs e)
    {
        var mapconfig_new = new MapConfig();
        MapStorage.configs.Add(mapconfig_new);
        var attributes = new Dictionary<string, object>() { { "mapConfig", mapconfig_new } };
        Shell.Current.GoToAsync(nameof(MapEditorPage), attributes);
    }

    // TODO: Add export button to actually use this method
    private async void ExportJson(string mapName)
    {
        Stream serializedMap = await MapStorage.ExportJsonMapByName(mapName);

        AppFileSaver.SaveFile(serializedMap, $"{mapName}.json");
    }
}