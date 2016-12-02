using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;

namespace ReMacro.TestMacros
{
    [ZoneMarker]
    public class ZoneMaker : IRequire<ICodeEditingZone>
    {
    }
}
