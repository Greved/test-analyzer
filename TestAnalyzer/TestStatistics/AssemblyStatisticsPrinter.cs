using System.IO;
using Newtonsoft.Json;
using TestAnalyzer.TestStatistics.Data.ByCategory;

namespace TestAnalyzer.TestStatistics
{
    public class AssemblyStatisticsPrinter : IAssemblyStatisticsPrinter
    {
        public string Print(AssemblyTestStatisticsByCategory assemblyTestStatistics)
        {
            var formattedTestStatistics = JsonConvert.SerializeObject(assemblyTestStatistics, Formatting.Indented);
            var filename = $"{assemblyTestStatistics.AssemblyName}.TestStatistics.json";
            File.WriteAllText(filename, formattedTestStatistics);
            return filename;
        }
    }
}