using System.Collections.Generic;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.Util;

namespace ReMacro.TestMacros
{
    [MacroDefinition("ReMacro.TestMacros.TestSubjectMacro",
        ShortDescription = "Current Filename without \"Test(s)\" and the file Extension",
        LongDescription = "The current filenae without the extension and removes the word \"Test(s)\" if end of the filename")]
    public class TestSubjectMacroDefinition : IMacroDefinition
    {
        public string GetPlaceholder(IDocument document, IEnumerable<IMacroParameterValue> parameters)
        {
            return "a";
        }

        public ParameterInfo[] Parameters => EmptyArray<ParameterInfo>.Instance;
    }
}

