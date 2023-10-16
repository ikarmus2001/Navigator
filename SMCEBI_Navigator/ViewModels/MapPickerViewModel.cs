using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapPickerViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<MapConfig> maps;

    public MapPickerViewModel()
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
    }

    internal async void UpdateVM()
    {
        Maps = new ObservableCollection<MapConfig>(MapStorage.configs);
    }

    internal void SelectMap(MainNavigationPage navPage, Dictionary<string, object> query)
    {
        navPage.ShowEditor(query);
    }

    internal void ShowMap(MainNavigationPage navPage)
    {
        navPage.ShowMap();
    }
}
