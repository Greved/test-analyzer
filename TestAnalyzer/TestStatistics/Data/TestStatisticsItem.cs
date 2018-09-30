using System.Collections.Generic;

namespace TestAnalyzer.TestStatistics.Data
{
    public class TestStatisticsItem
    {
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public string Description { get; set; }
        public string Fixture { get; set; }
    }
}