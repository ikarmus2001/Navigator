using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapEditorViewModel : ObservableObject
{
    [ObservableProperty] private MapConfig editedMap;

    public MapEditorViewModel(MapConfig mapToEdit)
    {
        // TODO: Work on new, copied object
        EditedMap = mapToEdit;
    }

    internal async Task AddFloor()
    {
        var addedFloor = new Floor();
        var param = new Dictionary<string, object>()
        {
            { nameof(Building), EditedMap.Building },
            { nameof(BuildingElement), addedFloor },
            //{ nameof(FeatureAction), FeatureAction.Add },
            { nameof(Type), typeof(Floor) }
        };
        await Shell.Current.GoToAsync(nameof(FeatureEditorPage), param);
    }
}
