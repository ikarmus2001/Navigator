using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.ViewModels;

// TODO: Change Add to Modify - make page more reusable

internal partial class AddFeatureViewModel : ObservableObject
{
    private MapConfig mapRef;
    [ObservableProperty] private string addedFeatureName;

    public AddFeatureViewModel(IDictionary<string, object> query)
    {
        mapRef = query[nameof(MapEditorViewModel)] as MapConfig;
        PrepareContent(query[nameof(Object)] as Type);
    }

    private async void PrepareContent(Type type)
    {
        if (type == typeof(Floor))
        {
            await PrepareFloor();
        }
        else if (type == typeof(Room))
        {
            await PrepareRoom();
        }
        else if (type == typeof(MarkedFeature))
        {
            await PrepareFeature();
        }
    }

    private async Task PrepareFeature()
    {
        AddedFeatureName = "Feature";
    }

    private async Task PrepareRoom()
    {
        AddedFeatureName = "Room";
    }

    private async Task PrepareFloor()
    {
        AddedFeatureName = "Floor";
    }
}
