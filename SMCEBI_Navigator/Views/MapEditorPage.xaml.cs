using SMCEBI_Navigator.Models;
using System.Text.Json;

namespace SMCEBI_Navigator.Views;

public partial class MapEditorPage : ContentPage, IQueryAttributable
{
    public MapEditorPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = query["mapConfig"] as MapConfig;
    }

    private async void LoadMapBtn_Clicked(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync();
        if (file == null)
        {
            return;
        }

        var building = await UnparseJsonBuildingAsync(await file.OpenReadAsync());
        var mapConfig = BindingContext as MapConfig;
        mapConfig.Building = building;
        mapConfig.HtmlChangeId++;
    }

    private static async Task<Building> UnparseJsonBuildingAsync(Stream inputJson)
    {
        return await JsonSerializer.DeserializeAsync<Building>(inputJson);
    }

    private void SaveMapBtn_Clicked(object sender, EventArgs e)
    {

    }

    private void ImportJSONToolbarBtn_Clicked(object sender, EventArgs e)
    {

    }
}