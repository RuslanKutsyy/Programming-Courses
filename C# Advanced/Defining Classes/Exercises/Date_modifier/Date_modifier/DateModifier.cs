using System;
using System.Collections.Generic;
using System.Text;

namespace Date_modifier
{
    public class DateModifier
    {
        public static void DateDiff(string date1, string date2)
        {
            DateTime firstDate = DateTime.Parse(date1);
            DateTime secondDate = DateTime.Parse(date2);

            double dateDifference = (firstDate - secondDate).TotalDays;

            Console.WriteLine(Math.Abs(dateDifference));
        }
    }
}
