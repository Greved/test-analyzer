using FluentAssertions;
using NUnit.Framework;
using Tests.To.Analyze.BusinessData;
using Tests.To.Analyze.Tests.Categories;

namespace Tests.To.Analyze.Tests
{
    [TestFixture]
    [Dogs]
    public class BusinessDataProviderTests
    {
        private BusinessDataProvider provider;

        [SetUp]
        public void Setup()
        {
            provider = new BusinessDataProvider();
        }

        [Test]
        [Description("Get method should return anything")]
        public void Get_Should_Return_Not_Null_Result()
        {
            var actual = provider.Get(4);
            actual.Should().NotBeNull();
        }

        [Test]
        [Chickens]
        [Pigs]
        [Description("IntProp should be equal to multiplier * 2")]
        public void Get_Should_Correctly_Calculate_IntProp()
        {
            var actual = provider.Get(4);
            actual.IntProp.Should().Be(8);
        }

        [Test]
        [Pigs]
        [Description("AnotherIntProp should be equal to multiplier * 4")]
        public void Get_Should_Correctly_Calculate_AnotherIntProp()
        {
            var actual = provider.Get(4);
            actual.AnotherIntProp.Should().Be(16);
        }
    }
}