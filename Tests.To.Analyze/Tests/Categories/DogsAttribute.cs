using NUnit.Framework;

namespace Tests.To.Analyze.Tests.Categories
{
    public class DogsAttribute: CategoryAttribute
    {
        public DogsAttribute() : base("Dogs")
        {
        }
    }
}