namespace TestAnalyzer.TestStatistics.AssembliesToAnalyzeSupport
{
    public interface IAssembliesToAnalyzeProvider
    {
        AssembliesToAnalyze Get(string pathToAssembly);
    }
}