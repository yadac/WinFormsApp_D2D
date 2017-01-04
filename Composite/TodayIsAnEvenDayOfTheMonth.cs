using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class TodayIsAnEvenDayOfTheMonth : IPredicate
    {
        private readonly DateTester dateTester;
        public TodayIsAnEvenDayOfTheMonth(DateTester dateTester)
        {
            this.dateTester = dateTester;
        }

        public bool Test()
        {
            return dateTester.TodayIsAnEvenDayOfTheMonth;
        }
    }
}
