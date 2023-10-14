using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.ViewModels;
using System.Text.Json;
using VM = SMCEBI_Navigator.ViewModels.MapEditorViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapEditorPage : ContentPage, IQueryAttributable
{
    MapConfig orgMapConfig;
    public MapEditorPage()
    {
        InitializeComponent();
    }

    public MapEditorPage(IDictionary<string, object> query)
    {
        InitializeComponent();
        orgMapConfig = query[nameof(MapConfig)] as MapConfig;
        BindingContext = new VM(orgMapConfig);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        orgMapConfig = query[nameof(MapConfig)] as MapConfig;
        BindingContext = new VM(orgMapConfig);
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
        ((MapEditorViewModel)BindingContext).SaveMap();
        Navigation.PopModalAsync();
    }

    private void ImportJSONToolbarBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void addFloor_imgBtn_Clicked(object sender, EventArgs e)
    {
        var floorParams = await ((VM)BindingContext).AddFloor();
        FeatureEditorPage featureEditorPage = new(floorParams);
        await Navigation.PushModalAsync(featureEditorPage);
    }
}