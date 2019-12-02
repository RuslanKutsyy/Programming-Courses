using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {

        private int MinValue { get; }
        private int MaxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
