using NUnit.Framework;

namespace Tests.To.Analyze.Tests.Categories
{
    public class CatsAttribute : CategoryAttribute
    {
        public CatsAttribute() : base("Cats")
        {
        }
    }
}