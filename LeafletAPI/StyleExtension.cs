using MapBuilder_API_Base;

namespace LeafletAPI;

internal static class StyleExtension
{
#nullable enable
    internal static Dictionary<string, string?> GetOptionalProperties(this MapObjectStyle style)
    {
        return new Dictionary<string, string?>()
        {
            {nameof(style.FillOpacity), style.FillOpacity.ToString() },
            {nameof(style.Weight), style.Weight.ToString() },
            {nameof(style.Opacity), style.Opacity.ToString() },
            {nameof(style.FillColor), style.FillColor }
        };
    }

    internal static string ToHtmlDefinition(this MapObjectStyle style)
    {
        string optionalParameters = "";
        foreach (var optionalPar in style.GetOptionalProperties())
        {
            if (!string.IsNullOrEmpty(optionalPar.Value))
                optionalParameters += $",{optionalPar.Key}: {optionalPar.Value}";
        }

        return $@"var {style.Name} = {{
            color: '{style.Color}'
            {optionalParameters}
        }};";
    }
#nullable disable
}
