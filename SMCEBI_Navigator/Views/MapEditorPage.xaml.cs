using SMCEBI_Navigator.Models;
using System.Text.Json;

namespace SMCEBI_Navigator.Views;

public partial class MapEditorPage : ContentPage, IQueryAttributable
{
    MapConfig orgMapConfig;
    public MapEditorPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        orgMapConfig = query["mapConfig"] as MapConfig;
        var copiedConfig = orgMapConfig.Copy();
        BindingContext = copiedConfig;
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
        var changedConfig = BindingContext as MapConfig;
        orgMapConfig.Engine = changedConfig.Engine;
        orgMapConfig.Building = changedConfig.Building;
        orgMapConfig.MapSize = changedConfig.MapSize;
        // TODO: Save commited versions in app cache, make use of version etc.
    }

    private void ImportJSONToolbarBtn_Clicked(object sender, EventArgs e)
    {

    }
}