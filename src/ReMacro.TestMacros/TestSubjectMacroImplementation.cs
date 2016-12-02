using System;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ReMacro.TestMacros
{
    [MacroImplementation(Definition = typeof(TestSubjectMacroDefinition))]
    public class TestSubjectMacroImplementation : SimpleMacroImplementation
    {
        public override string EvaluateQuickResult(IHotspotContext context)
        {
            var filename = System.IO.Path.GetFileNameWithoutExtension(context.ExpressionRange.Document.Moniker);
            
            if (filename.EndsWith("Test", StringComparison.CurrentCultureIgnoreCase) ||
                filename.EndsWith("Tests", StringComparison.CurrentCultureIgnoreCase))
            {
                return filename.Remove(filename.LastIndexOf("Test", StringComparison.CurrentCultureIgnoreCase));
            }
            
            return filename;
        }
    }
}