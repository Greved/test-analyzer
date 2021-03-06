﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public class TestStatisticsItemsProvider : ITestStatisticsItemsProvider
    {
        private static List<string> defaultCategoriesList = new List<string>(1) {"NoCategory"};

        public List<TestStatisticsItem> Get(Type[] types)
        {
            var testStatisticsItems = new List<TestStatisticsItem>();

            foreach (var type in types.Where(x => x.IsDefined(typeof(TestFixtureAttribute), true)))
            {
                var fixtureName = type.Name;
                var fixtureCategories = type.GetCustomAttributes<CategoryAttribute>().Select(x => x.Name).ToList();
                var fixtureTests = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.IsDefined(typeof(TestAttribute), false));
                foreach (var fixtureTest in fixtureTests)
                {
                    var testName = fixtureTest.Name;
                    var testDescription = fixtureTest.GetCustomAttribute<DescriptionAttribute>()?.Description;
                    var testCategories = fixtureTest.GetCustomAttributes<CategoryAttribute>().Select(x => x.Name).Concat(fixtureCategories).ToList();
                    var finalCategories = testCategories.Count == 0 ? defaultCategoriesList : testCategories;
                    var testStatisticsItem = new TestStatisticsItem
                    {
                        Name = testName,
                        Description = testDescription,
                        Categories = finalCategories,
                        Fixture = fixtureName
                    };
                    testStatisticsItems.Add(testStatisticsItem);
                }
            }

            return testStatisticsItems;
        }
    }
}