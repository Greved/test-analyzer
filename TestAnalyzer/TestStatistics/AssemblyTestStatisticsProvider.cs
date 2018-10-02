using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TestAnalyzer.TestStatistics.AssembliesToAnalyzeSupport;
using TestAnalyzer.TestStatistics.Data;

namespace TestAnalyzer.TestStatistics
{
    public class AssemblyTestStatisticsProvider : IAssemblyTestStatisticsProvider
    {
        private readonly ITestStatisticsItemsProvider testStatisticsItemsProvider;
        private readonly IAssembliesToAnalyzeProvider assembliesToAnalyzeProvider;

        public AssemblyTestStatisticsProvider(ITestStatisticsItemsProvider testStatisticsItemsProvider, 
                                              IAssembliesToAnalyzeProvider assembliesToAnalyzeProvider)
        {
            this.testStatisticsItemsProvider = testStatisticsItemsProvider;
            this.assembliesToAnalyzeProvider = assembliesToAnalyzeProvider;
        }

        public AssemblyTestStatistics Get(string pathToAssembly)
        {
            var assembliesToAnalyze = assembliesToAnalyzeProvider.Get(pathToAssembly);

            var types = assembliesToAnalyze.Assemblies.SelectMany(x => x.GetTypes()).ToArray();
            var items = testStatisticsItemsProvider.Get(types);
            var assemblyTestStatistics = new AssemblyTestStatistics
            {
                AssemblyName = assembliesToAnalyze.AssemblyWithTestsName,
                Items = items
            };
            return assemblyTestStatistics;
        }
    }
}