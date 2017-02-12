using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortCord
{
    public class SCA001
    {
        private List<SCAPerson> persons;
        private List<SCAPerson> primeMinisters;

        private void InitializeData()
        {
            persons = new List<SCAPerson>()
            {
                new SCAPerson()
                {
                    FirstName = "adachi",
                    LastName = "yosuke",
                    Age = 34,
                },
                new SCAPerson()
                {
                    FirstName = "hashimoto",
                    LastName = "ryutaro",
                    Age = 60,
                },
                new SCAPerson()
                {
                    FirstName = "adachi",
                    LastName = "kumi",
                    Age = 35,
                },
                new SCAPerson()
                {
                    FirstName = "adachi",
                    LastName = "keisuke",
                    Age = 30,
                },
                new SCAPerson()
                {
                    FirstName = "aso",
                    LastName = "taro",
                    Age = 70,
                },
            };

            primeMinisters = new List<SCAPerson>()
            {
                new SCAPerson()
                {
                    FirstName = "hashimoto",
                    LastName = "ryutaro",
                    Age = 60,
                },
                new SCAPerson()
                {
                    FirstName = "aso",
                    LastName = "taro",
                    Age = 70,
                },
            };
        }

        public SCA001()
        {
            this.InitializeData();
            //foreach (var person in persons)
            //    Console.WriteLine($"{person.FirstName} {person.LastName}");
            //Console.WriteLine("-------");
            persons = persons.FindAll(IsNotPrimeMinister).ToList();
            foreach (var person in persons)
                Console.WriteLine($"{person.FirstName} {person.LastName}");
        }

        private bool IsNotPrimeMinister(SCAPerson obj)
        {
            return !primeMinisters.Any(c => c.FirstName.Equals(obj.FirstName));
        }
    }

    public class SCAPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}