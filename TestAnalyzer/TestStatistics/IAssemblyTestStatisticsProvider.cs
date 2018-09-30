using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public interface IAssemblyTestStatisticsProvider
    {
        AssemblyTestStatistics Get(string pathToAssembly);
    }
}