using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using System.Collections.ObjectModel;

using FA = SMCEBI_Navigator.ViewModels.FeatureAction;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapPickerViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<MapConfig> maps;

    public MapPickerViewModel()
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
    }

    internal void UpdateVM()
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
    }

    internal static void ShowMap(MainNavigationPage navPage)
    {
        navPage.ShowMap();
    }

    internal static async Task GoToEditor(Building building, FA fa, INavigation navi) =>
        await navi.PushAsync(new FeatureEditorPage(ObjectExtensions.NavigationParams(building, building, fa)));
}
