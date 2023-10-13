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

    internal void SelectMap()
    {
        //throw new NotImplementedException();
    }
}
