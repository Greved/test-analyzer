using System;
using System.Linq;

namespace TestAnalyzer
{
    public class AssemblyToAnalyzePathProvider : IAssemblyToAnalyzePathProvider
    {
        public string Get(string[] commandLineArguments)
        {
            if (commandLineArguments.Length != 1)
            {
                throw new Exception("You must specify path to test assembly as the single argument");
            }

            return commandLineArguments.Single();
        }
    }
}