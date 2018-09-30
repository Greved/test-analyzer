using TestAnalyzer.TestStatistics.Data.ByCategory;

namespace TestAnalyzer.TestStatistics
{
    public interface IAssemblyStatisticsPrinter
    {
        void Print(AssemblyTestStatisticsByCategory assemblyTestStatistics, string filename);
    }
}