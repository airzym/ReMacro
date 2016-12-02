using FluentAssertions;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using Moq.AutoMock;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ReMacro.TestMacros.Tests
{
    public class TestSubjectMacroDefinitionTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        [SetUp]
        public void SetUp()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Test]
        public void WhenGetPlaceholder()
        {
            var subject = Mocker.CreateInstance<TestSubjectMacroDefinition>();
            const string expectedValue = "a";
            var iDocumentMock = Mocker.GetMock<IDocument>();
            var macroParameterValues = new[]
            {
                Mocker.GetMock<IMacroParameterValue>().Object,
                Mocker.GetMock<IMacroParameterValue>().Object,
                Mocker.GetMock<IMacroParameterValue>().Object
            };
        
            var result = subject.GetPlaceholder(iDocumentMock.Object, macroParameterValues);
        
            result.Should().Be(expectedValue);
        }
        
        [Test]
        public void WhenParameters()
        {
            var subject = Mocker.CreateInstance<TestSubjectMacroDefinition>();
        
            var result = subject.Parameters;
        
            result.Should().BeEmpty();
        }
    }
}