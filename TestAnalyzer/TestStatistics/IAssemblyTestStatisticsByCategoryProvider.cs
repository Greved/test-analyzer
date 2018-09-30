using TestAnalyzer.TestStatistics.Data;
using TestAnalyzer.TestStatistics.Data.ByCategory;

namespace TestAnalyzer.TestStatistics
{
    public interface IAssemblyTestStatisticsByCategoryProvider
    {
        AssemblyTestStatisticsByCategory Get(AssemblyTestStatistics assemblyTestStatistics);
    }
}