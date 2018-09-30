using System;

namespace Tests.To.Analyze.BusinessData
{
    public class BusinessDataProcessor
    {
        public int Calculate(BusinessData data)
        {
            if (data == null)
            {
                throw new Exception("Can't calculate result for null business data");
            }

            return data.AnotherIntProp * data.IntProp;
        }
    }
}