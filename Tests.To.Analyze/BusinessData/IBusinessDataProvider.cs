namespace Tests.To.Analyze.BusinessData
{
    public interface IBusinessDataProvider
    {
        BusinessData Get(int multiplier);
    }
}