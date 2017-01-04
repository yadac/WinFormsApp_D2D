using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SQLiteConnection hConnection = new SQLiteConnection("Data Source=test.db"))
            {
                string mySelectQuery = "SELECT name FROM test_tbl where name like 'adac%'";
                SQLiteCommand myCommand = new SQLiteCommand(mySelectQuery, hConnection);
                // データベース接続を開く
                hConnection.Open();
                try
                {
                    SQLiteDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        string hi = myReader.GetString(0);
                        Console.WriteLine("hello {0}", hi);
                        // string ad = myReader.GetString(1);
                        // Console.WriteLine(hi + " " + ad);
                    }

                    myReader.Close();

                    hConnection.Close();
                    hConnection.Dispose();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
            }
            Console.Read();
        }
    }
}
