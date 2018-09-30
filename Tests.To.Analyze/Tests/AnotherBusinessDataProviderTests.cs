using FluentAssertions;
using NUnit.Framework;
using Tests.To.Analyze.BusinessData;
using Tests.To.Analyze.Tests.Categories;

namespace Tests.To.Analyze.Tests
{
    [TestFixture]
    [Cats]
    public class AnotherBusinessDataProviderTests
    {
        [Test]
        [Pigs]
        [Description("If multiplier is zero the IntProp and AnotherIntProp should be zero too")]
        public void Get_Should_Correctly_Process_Zero_Multiplier()
        {
            var actual = new BusinessDataProvider().Get(0);
            actual.IntProp.Should().Be(0);
            actual.AnotherIntProp.Should().Be(0);
        }

        [Test]
        [Description("Big multipliers should also work")]
        public void Get_Should_Work_For_Big_Multipliers()
        {
            var actual = new BusinessDataProvider().Get(1500);
            actual.IntProp.Should().Be(3000);
            actual.AnotherIntProp.Should().Be(6000);
        }
    }
}