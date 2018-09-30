namespace Tests.To.Analyze.BusinessData
{
    public class BusinessDataProvider : IBusinessDataProvider
    {
        public BusinessData Get(int multiplier)
        {
            return new BusinessData
            {
                IntProp = multiplier * 2,
                AnotherIntProp = multiplier * 4
            };
        }
    }
}