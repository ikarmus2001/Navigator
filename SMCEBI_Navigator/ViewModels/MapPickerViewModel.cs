using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using System.Collections.ObjectModel;

using FA = SMCEBI_Navigator.ViewModels.FeatureAction;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapPickerViewModel : ObservableObject
{
    private readonly INavigation navi;
    [ObservableProperty] private ObservableCollection<MapConfig> maps;

    public MapPickerViewModel(INavigation navi)
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
        this.navi = navi;
    }

    internal void UpdateVM()
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
    }

    internal static void ShowMap(MainNavigationPage navPage)
    {
        navPage.ShowMap();
    }

    internal async Task GoToEditor(Building building, FA fa) =>
        await navi.PushAsync(new FeatureEditorPage(ObjectExtensions.NavigationParams(building, building, fa)));
}
