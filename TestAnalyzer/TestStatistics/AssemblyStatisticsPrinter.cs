using System.IO;
using Newtonsoft.Json;
using TestAnalyzer.TestStatistics.Data.ByCategory;

namespace TestAnalyzer.TestStatistics
{
    public class AssemblyStatisticsPrinter : IAssemblyStatisticsPrinter
    {
        public void Print(AssemblyTestStatisticsByCategory assemblyTestStatistics, string filename)
        {
            var formattedTestStatistics = JsonConvert.SerializeObject(assemblyTestStatistics, Formatting.Indented);
            File.WriteAllText(filename, formattedTestStatistics);
        }
    }
}