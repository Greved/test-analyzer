using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public class TestStatisticsItemsProvider : ITestStatisticsItemsProvider
    {
        public List<TestStatisticsItem> Get(Type[] types)
        {
            var testStatisticsItems = new List<TestStatisticsItem>();

            foreach (var type in types.Where(x => x.IsDefined(typeof(TestFixtureAttribute), false)))
            {
                var fixtureName = type.Name;
                var fixtureCategories = type.GetCustomAttributes<CategoryAttribute>().Select(x => x.Name).ToList();
                var fixtureTests = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.IsDefined(typeof(TestAttribute), false));
                foreach (var fixtureTest in fixtureTests)
                {
                    var testName = fixtureTest.Name;
                    var testDescription = fixtureTest.GetCustomAttribute<DescriptionAttribute>()?.Properties?.Get(PropertyNames.Description) as string;
                    var testCategories = fixtureTest.GetCustomAttributes<CategoryAttribute>().Select(x => x.Name).Concat(fixtureCategories).ToList(); //TODO: count can be calculated
                    var testStatisticsItem = new TestStatisticsItem
                    {
                        Name = testName,
                        Description = testDescription,
                        Categories = testCategories,
                        Fixture = fixtureName
                    };
                    testStatisticsItems.Add(testStatisticsItem);
                }
            }

            return testStatisticsItems;
        }
    }
}