using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.ViewModels;

internal partial class FeatureEditorViewModel : ObservableObject
{
    private Building buildingRef;
    [ObservableProperty] private string featureName;

    FeatureAction action;
    private BuildingElement editorElement;

    //internal delegate Action<BuildingElement> SaveDelegate();

    //internal event Action<BuildingElement> SaveEvent;

    public FeatureEditorViewModel(IDictionary<string, object> query)
    {
        buildingRef = query[nameof(Building)] as Building;
        editorElement = query[nameof(BuildingElement)] as BuildingElement;
        //action = (FeatureAction)Enum.Parse(typeof(FeatureAction), query[nameof(FeatureAction)].ToString());
        PrepareContent(query[nameof(Type)] as Type);
    }

    private async void PrepareContent(Type elementType)
    {
        // TODO IK it look awful, cant find suitable syntax for type pattern matching switch
        if (elementType == typeof(Floor))
        {
            await PrepareFloor();
        }
        else if (elementType == typeof(Room))
        {
            await PrepareRoom();
        }
        else if (elementType == typeof(MarkedFeature))
        {
            await PrepareFeature();
        } 
    }

    private async Task PrepareFeature()
    {
        FeatureName = "Feature";
        
    }

    private async Task PrepareRoom()
    {
        FeatureName = "Room";
    }

    private async Task PrepareFloor()
    {
        FeatureName = "Floor";
        //SaveEvent += new Action<Floor>(buildingRef.AddFloor);
    }

    internal void Save()
    {
        
    }

    //internal async Task<bool> Save()
    //{
    //    if (action == FeatureAction.Add)
    //    {

    //    }
    //    return true;
    //}
}
