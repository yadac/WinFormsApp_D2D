using System;

namespace Composite
{
    public class DateTester
    {
        public bool TodayIsAnEvenDayOfTheMonth
        {
            get { return DateTime.Now.Day % 2 == 0; }
        }
    }
}