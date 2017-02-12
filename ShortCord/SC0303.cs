using System;
using System.Linq;

namespace ShortCord
{
    public class SC0303
    {
        public SC0303()
        {
            DateTime now = new DateTime(2014, 4, 1);
            SC0303Person[] persons =
            {
                new SC0303Person()
                {
                    Name = "yosuke",
                    Date = new DateTime(2014, 2, 26),
                },
                new SC0303Person()
                {
                    Name = "kune",
                    Date = new DateTime(2014, 3, 2),
                },
                new SC0303Person()
                {
                    Name = "keisuke",
                    Date = new DateTime(2014, 3, 27),
                },
            };
            foreach (var person in persons.Where(c => (now - c.Date).TotalDays > 7)) 
            {
                Console.WriteLine(person.Name);
            }
        }
    }

    public class SC0303Person
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}