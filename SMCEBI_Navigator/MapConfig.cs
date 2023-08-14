using System.Text;
using System.Text.Json;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator;

internal class MapConfig
{
    internal Building building { get; set; }

    public static async Task<MapConfig> UnparseJson(string inputJson)
    {
        if (inputJson == null || inputJson.Length < 1)
            throw new ArgumentException("Json can't be empty");

        Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(inputJson));

        return await JsonSerializer.DeserializeAsync<MapConfig>(jsonStream);
    }
}