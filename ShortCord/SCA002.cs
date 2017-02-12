using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCord
{
    class SCA002 : ISampleCode
    {
        public SCA002()
        {
            DoWork();
        }

        public void DoWork()
        {
            Member[] members = new Member[]
            {
                new Human() {Name = "たろう"},
                new Mouse() {Name = "ネズミ－マウス"},
            };
            foreach (var item in members.OfType<Mouse>())
                item.しっぽをたてろ();
                
            //foreach (var member in members)
            //    (member as IMember)?.しっぽをたてろ();
        }
    }

    public abstract class Member
    {
        internal string Name;
    }

    public interface IMember
    {
        void しっぽをたてろ();
    }

    public class Human : Member, IMember {
        public void しっぽをたてろ()
        {
            // nothing to do
        }
    }

    public class Mouse : Member, IMember
    {
        public virtual void しっぽをたてろ()
        {
            Console.WriteLine($"{Name}はしっぽをたてました");
        }
    }
}
