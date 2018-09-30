using System;
using System.Reflection;
using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public class AssemblyTestStatisticsProvider : IAssemblyTestStatisticsProvider
    {
        private readonly ITestStatisticsItemsProvider testStatisticsItemsProvider;

        public AssemblyTestStatisticsProvider(ITestStatisticsItemsProvider testStatisticsItemsProvider)
        {
            this.testStatisticsItemsProvider = testStatisticsItemsProvider;
        }

        public AssemblyTestStatistics Get(string pathToAssembly)
        {
            var testAssembly = Assembly.LoadFile(pathToAssembly);
            var assemblyName = testAssembly.GetName().Name;
            var items = testStatisticsItemsProvider.Get(testAssembly.GetTypes());
            var assemblyTestStatistics = new AssemblyTestStatistics
            {
                AssemblyName = assemblyName,
                Items = items
            };
            return assemblyTestStatistics;
        }
    }
}