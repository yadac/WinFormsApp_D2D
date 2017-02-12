using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    public class SC0402
    {
        public SC0402()
        {
            var list = new List<Item42>();
            foreach (var item in CreateItem())
                if (item.buyDate.Year >= 2010) list.Add(item);
            list.Sort((x, y) => Math.Sign(x.buyDate.Ticks - y.buyDate.Ticks));
            var itemList = new List<string>();
            foreach (var item in list)
            {
                if (itemList.Contains(item.ItemName)) continue;
                itemList.Add(item.ItemName);
                Console.WriteLine($"商品 = {item.ItemName}");
                foreach (var item2 in list)
                {
                    if (item2.ItemName != item.ItemName) continue;
                    Console.WriteLine($"\t買ったのは{item2.buyPersonName}さん");
                }
            }

            var q = CreateItem()
                .Where(c => c.buyDate.Year >= 2010)
                .OrderBy(c => c.buyDate)
                .GroupBy(c => c.ItemName);
            foreach (var n in q)
            {
                Console.WriteLine($"商品 = {n.Key}");
                foreach (var m in n)
                {
                    Console.WriteLine($"\t買ったのは{m.buyPersonName}さん");
                }
            }
        }

        private IEnumerable<Item42> CreateItem()
        {
            yield return new Item42() { buyDate = new DateTime(2009, 12, 20), buyPersonName = "太郎", ItemName = "gusTV" };
            yield return new Item42() { buyDate = new DateTime(2010, 4, 30), buyPersonName = "二郎", ItemName = "BSTuner" };
            yield return new Item42() { buyDate = new DateTime(2011, 5, 17), buyPersonName = "三郎", ItemName = "gusTV" };
            yield return new Item42() { buyDate = new DateTime(2012, 1, 3), buyPersonName = "花子", ItemName = "BSTuner" };
            yield return new Item42() { buyDate = new DateTime(2013, 3, 27), buyPersonName = "史朗", ItemName = "AMTuner" };
        }
    }

    public class Item42
    {
        internal DateTime buyDate;
        internal string buyPersonName;
        internal string ItemName;
    }
}
