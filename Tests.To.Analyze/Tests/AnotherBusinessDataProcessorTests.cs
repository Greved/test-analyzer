using FluentAssertions;
using NUnit.Framework;
using Tests.To.Analyze.BusinessData;

namespace Tests.To.Analyze.Tests
{
    [TestFixture]
    public class AnotherBusinessDataProcessorTests
    {
        private BusinessDataProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new BusinessDataProcessor();
        }

        [Test]
        [Description("Test should return zero if IntProp is zero. Even if AnotherIntProp is not zero")]
        public void Calculate_Should_Return_Zero_If_IntProp_Is_Zero()
        {
            var actual = processor.Calculate(new BusinessData.BusinessData {IntProp = 0, AnotherIntProp = 99});
            actual.Should().Be(0);
        }
    }
}