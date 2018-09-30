namespace TestAnalyzer
{
    public interface IAssemblyToAnalyzePathProvider
    {
        string Get(string[] commandLineArguments);
    }
}