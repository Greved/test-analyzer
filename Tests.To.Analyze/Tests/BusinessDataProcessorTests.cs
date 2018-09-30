using System;
using FluentAssertions;
using NUnit.Framework;
using Tests.To.Analyze.BusinessData;
using Tests.To.Analyze.Tests.Categories;

namespace Tests.To.Analyze.Tests
{
    [TestFixture]
    [Cats]
    public class BusinessDataProcessorTests
    {
        private BusinessDataProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new BusinessDataProcessor();
        }

        [Test]
        [Description("Calculate should just multiply two props of business data")]
        public void Calculate_Should_Multiply_IntProp_And_AnotherIntProp()
        {
            var data = new BusinessData.BusinessData
            {
                IntProp = 5,
                AnotherIntProp = 7
            };
            var actual = processor.Calculate(data);
            actual.Should().Be(35);
        }

        [Test]
        [Chickens]
        [Description("Calculate should throw exception with human readable text when business data is null")]
        public void Calculate_Should_Throw_When_Data_Is_Null()
        {
            Action calculateAction = () => processor.Calculate(null);
            calculateAction.Should().Throw<Exception>();
        }
    }
}