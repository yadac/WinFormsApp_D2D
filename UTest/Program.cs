using System.Text.RegularExpressions;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User() { Name = "yadachi" };
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; private set; }

        public void AddAge(int age)
        {
            Age += age;
        }

        public string Validate(string password)
        {
            if ((password.Length < 6) || (password.Length > 20))
                return "パスワードは6文字以上20文字以内で設定してください。";
            // 英語小文字と数字を含む文字列にマッチするパスワードを確認している 
            if (Regex.IsMatch(password, "^(?!(?!.{4,8}$))[0-9a-z]*([0-9][a-z]|[a-z][0-9])+[0-9a-z]*$")) return "OK";
            return "パスワードには数字、英字を両方含んでください";
        }

    }
}
