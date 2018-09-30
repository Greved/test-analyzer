using System;
using TestAnalyzer.TestStatistics;

namespace TestAnalyzer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Configure();
            
            var pathToAssemblyProvider = new AssemblyToAnalyzePathProvider();
            var pathToTestAssembly = pathToAssemblyProvider.Get(args); 
            Console.WriteLine($"Starting to analyze assembly {pathToTestAssembly}");

            var assemblyStatisticsProvider = new AssemblyTestStatisticsProvider(new TestStatisticsItemsProvider());
            var assemblyTestStatistics = assemblyStatisticsProvider.Get(pathToTestAssembly);
            Console.WriteLine($"{assemblyTestStatistics.Items?.Count} tests found");

            var assemblyStatisticsByCategoryProvider = new AssemblyTestStatisticsByCategoryProvider();
            var assemblyStatisticsByCategory = assemblyStatisticsByCategoryProvider.Get(assemblyTestStatistics);
            Console.WriteLine($"Tests succesfully grouped by categories. There are {assemblyStatisticsByCategory.TestsByCategory.Count} categories");

            var printer = new AssemblyStatisticsPrinter();
            var testStatisticsFilename = $"{assemblyStatisticsByCategory.AssemblyName}.TestStatistics.json";
            printer.Print(assemblyStatisticsByCategory, testStatisticsFilename);
            Console.WriteLine($"Test statistics succesfully saved to {testStatisticsFilename}");
        }

        private static void Configure()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Console.Out.WriteLine("Error: " + args.ExceptionObject);
            Environment.Exit(1);
        }
    }
}