using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.ViewModels;

internal partial class MapEditorViewModel : ObservableObject
{
    [ObservableProperty] private MapConfig editedMap;

    public MapEditorViewModel(MapConfig mapToEdit)
    {
        // TODO: Work on new, copied object
        EditedMap = mapToEdit;
    }


    /// <summary>
    /// Instantiates new floor in query form for FeatureEditorPage
    /// </summary>
    /// <returns>Query with newly instantiated floor</returns>
    internal Dictionary<string, object> GetFloorParams()
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="f"></param>
    /// <returns>Query with choosen Floor</returns>
    internal Dictionary<string, object> GetFloorParams(Floor f)
    {
        return new Dictionary<string, object>()
        {
            { nameof(Building), EditedMap.Building },
            { nameof(BuildingElement), f},
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
