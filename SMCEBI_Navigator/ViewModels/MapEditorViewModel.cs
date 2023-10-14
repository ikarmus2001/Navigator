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

    internal async Task<Dictionary<string, object>> AddFloor()
    {
        var addedFloor = new Floor();
        return new Dictionary<string, object>()
        {
            { nameof(Building), EditedMap.Building },
            { nameof(BuildingElement), addedFloor },
            //{ nameof(FeatureAction), FeatureAction.Add },
            { nameof(Type), typeof(Floor) }
        };
    }

    // TODO: Save commited versions in app cache, make use of version etc.
    internal void SaveMap()
    {
        //orgMapConfig.Engine = changedConfig.Engine;
        //orgMapConfig.Building = changedConfig.Building;
        //orgMapConfig.MapSize = changedConfig.MapSize;
        
    }
}
