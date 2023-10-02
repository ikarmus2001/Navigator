using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapEditorViewModel : ObservableObject
{
    [ObservableProperty] private MapConfig editedMap;

    public MapEditorViewModel(MapConfig mapToEdit)
    {
        EditedMap = mapToEdit.Copy();
    }

    internal async Task AddFloor()
    {
        var param = new Dictionary<string, object>() { { nameof(MapEditorViewModel), EditedMap }, { nameof(Object), typeof(Floor) } };
        await Shell.Current.GoToAsync(nameof(AddFeaturePage), param);
    }
}
