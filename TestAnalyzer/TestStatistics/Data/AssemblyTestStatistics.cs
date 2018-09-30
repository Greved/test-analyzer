using System.Collections.Generic;

namespace TestAnalyzer.TestStatistics.Data
{
    public class AssemblyTestStatistics
    {
        public string AssemblyName { get; set; }
        public List<TestStatisticsItem> Items { get; set; }
    }
}