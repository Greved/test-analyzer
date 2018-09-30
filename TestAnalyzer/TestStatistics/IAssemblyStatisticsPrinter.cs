using TestAnalyzer.TestStatistics.Data.ByCategory;

namespace TestAnalyzer.TestStatistics
{
    public interface IAssemblyStatisticsPrinter
    {
        string Print(AssemblyTestStatisticsByCategory assemblyTestStatistics);
    }
}