using FluentAssertions;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.Util;
using Moq.AutoMock;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace ReMacro.TestMacros.Tests
{
    [TestFixture]
    public class TestSubjectMacroImplementationTests
    {
        public AutoMocker Mocker { get; set; }
        public Fixture AutoFixture { get; set; }

        [SetUp]
        public void SetUp()
        {
            Mocker = new AutoMocker();
            AutoFixture = new Fixture();
        }

        [TestCase("")]
        [TestCase("Tests")]
        [TestCase("Test")]
        [TestCase("tests")]
        [TestCase("test")]
        public void WhenEvaluateQuickResult(string endOfFilename)
        {
            var subject = Mocker.CreateInstance<TestSubjectMacroImplementation>();
            var testSubject = AutoFixture.Create<string>();
            var contextMock = Mocker.GetMock<IHotspotContext>();
            var documentMock = Mocker.GetMock<IDocument>();
            var documentRange = new DocumentRange(documentMock.Object, AutoFixture.Create<TextRange>());
            Mocker.GetMock<IHotspotContext>().Setup(cm => cm.ExpressionRange).Returns(documentRange);
            documentMock.Setup(dm => dm.Moniker).Returns($"C:\\Test\\Path\\{testSubject}{endOfFilename}.cs");
            
            var result = subject.EvaluateQuickResult(contextMock.Object);
            
            result.Should().Be(testSubject);            
        }
    }
}