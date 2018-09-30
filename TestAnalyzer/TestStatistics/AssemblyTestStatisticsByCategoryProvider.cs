using System.Collections.Generic;
using TestAnalyzer.TestStatistics.Data;
using TestAnalyzer.TestStatistics.Data.ByCategory;
using TestAnalyzer.Utility;

namespace TestAnalyzer.TestStatistics
{
    public class AssemblyTestStatisticsByCategoryProvider : IAssemblyTestStatisticsByCategoryProvider
    {
        public AssemblyTestStatisticsByCategory Get(AssemblyTestStatistics assemblyTestStatistics)
        {
            var testsByCategory = new Dictionary<string, List<TestCategoryStatisticsItem>>();
            foreach (var testItem in assemblyTestStatistics.Items)
            {
                foreach (var testItemCategory in testItem.Categories)
                {
                    var categoryTests = testsByCategory.GetOrAdd(testItemCategory);
                    var testCategoryStatisticsItem = new TestCategoryStatisticsItem
                    {
                        Description = testItem.Description,
                        Fixture = testItem.Fixture,
                        Name = testItem.Name,
                    };
                    categoryTests.Add(testCategoryStatisticsItem);
                }
            }

            return new AssemblyTestStatisticsByCategory
            {
                AssemblyName = assemblyTestStatistics.AssemblyName,
                TestsByCategory = testsByCategory
            };
        }
    }
}