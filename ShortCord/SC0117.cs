using System;
using System.Collections.Generic;
using System.IO;

namespace ShortCord
{
    public class SC0117 : ISampleCode
    {
        public SC0117()
        {
            this.DoWork();
        }

        public void DoWork()
        {
            var q = new QuickTalk();
            q.AddTalker("t", Persons.a);
            q.AddTalker("h", Persons.b);
            q.Play(@"
t 犯人はお前だ！
h くっ、どうしてばれた。完全犯罪だったはずだ！
t お手伝いさんが見ていたんだよ。お前が裏口から台所に入り込むところをね。
h そ、そんな。
t その直後、不審に思ったお手伝いさんが台所に戻ってケーキの数を確認したんだ。
h まさか。
t そうだ。きみがたちさった後、ケーキが１つ減っていたのだ。だから食い逃げ犯はお前だ！
");
        }
    }

    public class Persons
    {
        public static Person a = new Person() { Name = "yosuke" };
        public static Person b = new Person() { Name = "kune" };
        public static Person c = new Person() { Name = "keisuke" };
    }

    public class Person
    {
        public string Name;

        public void Say(string s)
        {
            if (Name == " ") Console.WriteLine(s);
            else Console.WriteLine($"{Name}:{s}");
        }
    }

    public class QuickTalk
    {
        private Dictionary<string, Person> talkers = new Dictionary<string, Person>();

        public void Play(string text)
        {
            char[] whiteSpaces = {' ', '\t', '　'};
            StringReader reader = new StringReader(text);
            for (;;)
            {
                string s = reader.ReadLine();
                if (s == null) break;
                s = s.Trim();
                if (s.Length == 0) continue;
                Person talker = null;
                string body;
                int firstWhiteSpacePos = s.IndexOfAny(whiteSpaces);
                if (firstWhiteSpacePos < 0 || firstWhiteSpacePos > 2)
                {
                    talker = Persons.c;
                    body = s;
                }
                else
                {
                    string shortName = s.Substring(0, firstWhiteSpacePos);
                    if (talkers.ContainsKey(shortName))
                    {
                        talker = talkers[shortName];
                    }
                    if (talker == null)
                    {
                        throw new ArgumentException(
                            $"WuickTalk構文エラー {shortName}は定義されていない短いTalker名です");
                    }
                    body = s.Substring(firstWhiteSpacePos + 1).Trim();
                }
                talker.Say(body);
            }
        }

        public void AddTalker(string shortName, Person talker)
        {
            talkers[shortName] = talker;
        }
    }
}