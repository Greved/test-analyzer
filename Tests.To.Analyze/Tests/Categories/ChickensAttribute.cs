using NUnit.Framework;

namespace Tests.To.Analyze.Tests.Categories
{
    public class ChickensAttribute : CategoryAttribute
    {
        public ChickensAttribute() : base("Chickens")
        {
        }
    }
}