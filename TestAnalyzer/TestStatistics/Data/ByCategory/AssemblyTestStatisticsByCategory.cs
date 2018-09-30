using System.Collections.Generic;

namespace TestAnalyzer.TestStatistics.Data.ByCategory
{
    public class AssemblyTestStatisticsByCategory
    {
        public string AssemblyName { get; set; }
        public Dictionary<string, List<TestCategoryStatisticsItem>> TestsByCategory { get; set; }
    }
}