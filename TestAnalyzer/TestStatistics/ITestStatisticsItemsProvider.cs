using System;
using System.Collections.Generic;
using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public interface ITestStatisticsItemsProvider
    {
        List<TestStatisticsItem> Get(Type[] types);
    }
}