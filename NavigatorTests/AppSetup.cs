using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;

namespace NavigatorTests;

public class AppSetup
{
    [Fact]
    public async Task SaveMap_ShouldSaveMapToFile()
    {
        string mapName = "TestMap";
        string location = Path.GetTempPath();
        
        var mapConfig = new MapConfig();
        mapConfig.Building.Name = mapName;

        

        MapStorage.configs.Add(mapConfig);

        await FileManager.SaveMap(mapConfig, location);

        File.Exists(Path.Combine(location, mapConfig.Building.Name + ".json")).Should().BeTrue();
    }
}
