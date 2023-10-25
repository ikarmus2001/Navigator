using SMCEBI_Navigator.Models;
using System.Text.Json;
using VM = SMCEBI_Navigator.ViewModels.MapEditorViewModel;

namespace SMCEBI_Navigator.Views;

public partial class MapEditorPage : ContentPage, IQueryAttributable
{
    MapConfig orgMapConfig;
    public MapEditorPage()
    {
        InitializeComponent();
        NavigatedFrom += MapEditorPage_NavigatedFrom;
    }

    private async void MapEditorPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        await orgMapConfig.SaveChanges();
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

    private static async Task<Building> UnparseJsonBuildingAsync(Stream inputJson)
    {
        return await JsonSerializer.DeserializeAsync<Building>(inputJson);
    }

    private void SaveMapBtn_Clicked(object sender, EventArgs e)
    {
        ((VM)BindingContext).SaveMap();
        Navigation.PopAsync();
    }

    private void ImportJSONToolbarBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void AddFloor_imgBtn_Clicked(object sender, EventArgs e)
    {
        var floorParams = ((VM)BindingContext).GetFloorParams();
        //new MainNavigationPage()
        await Navigation.PushAsync(new FeatureEditorPage(floorParams));
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0) return;

        var floorParams = ((VM)BindingContext).GetFloorParams(e.CurrentSelection.FirstOrDefault() as Floor);
        //new MainNavigationPage(
        await Navigation.PushAsync(new FeatureEditorPage(floorParams));
        (sender as CollectionView).SelectedItem = null;
    }
}