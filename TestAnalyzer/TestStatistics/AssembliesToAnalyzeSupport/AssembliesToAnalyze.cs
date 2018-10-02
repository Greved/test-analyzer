using System.Reflection;

namespace TestAnalyzer.TestStatistics.AssembliesToAnalyzeSupport
{
    public class AssembliesToAnalyze
    {
        public Assembly[] Assemblies { get; set; }
        public string AssemblyWithTestsName { get; set; }
    }
}