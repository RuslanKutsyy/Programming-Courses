using System;
namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {

        private readonly int MinValue;
        private readonly int MaxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int ValueAsInt)
            {
                if (ValueAsInt >= MinValue && ValueAsInt <= MaxValue)
                {
                    return true;
                }
                return false;
            }

            throw new ArgumentException("Invalid type!");
        }
    }
}
