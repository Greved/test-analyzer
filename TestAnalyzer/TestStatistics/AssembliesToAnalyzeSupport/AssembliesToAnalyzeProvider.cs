using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TestAnalyzer.TestStatistics.AssembliesToAnalyzeSupport
{
    public class AssembliesToAnalyzeProvider : IAssembliesToAnalyzeProvider
    {
        public AssembliesToAnalyze Get(string pathToAssembly)
        {
            var folderName = Path.GetDirectoryName(pathToAssembly);
            if (string.IsNullOrEmpty(folderName))
            {
                throw new Exception($"Can't recognize foldername for assembly: {pathToAssembly}");
            }

            var testAssembly = Assembly.LoadFile(pathToAssembly);
            var assembliesNames = string.Join("|", testAssembly.GetReferencedAssemblies().Select(x => x.Name));
            var regexPattern = new Regex($@"{assembliesNames}", RegexOptions.Compiled);
            var matchedAssemblies = Directory.EnumerateFiles(folderName, "*.*", SearchOption.AllDirectories)
                .Where(x => regexPattern.IsMatch(x) && (x.EndsWith(".dll") || x.EndsWith(".exe"))).ToArray();
            foreach (var matchedAssembly in matchedAssemblies)
            {
                var destFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(matchedAssembly));
                File.Copy(matchedAssembly, destFileName, true);
            }

            var assemblies = matchedAssemblies
                .Select(Assembly.LoadFrom)
                .Concat(new[] { testAssembly })
                .ToArray();
            return new AssembliesToAnalyze
            {
                Assemblies = assemblies,
                AssemblyWithTestsName = testAssembly.GetName().Name
            };
        }
    }
}