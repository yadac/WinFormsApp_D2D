using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;
using System.Data.SQLite;

namespace SOLIDConcreates
{
    public class AdoNetTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        public AdoNetTradeStorage(ILogger logger)
        {
            this.logger = logger;
        }

        public void Persist(IEnumerable<TradeRecord> tradeRecords)
        {
            // データベースに登録
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=test.db"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    //foreach (var trade in trades)
                    //{
                    //    var command = connection.CreateCommand();
                    //    command.Transaction = transaction;
                    // command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.CommandText = "dbo.insert_trade";
                    //command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                    //command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                    //command.Parameters.AddWithValue("[lots", trade.Lots);
                    //command.Parameters.AddWithValue("@price", trade.Price);
                    //command.ExecuteNonQuery();
                    // todo : commandtextでinsert文作成してexecutenonqueryでexecute
                    //}
                    //transaction.Commit();
                }
                connection.Close();
            }
            // Console.WriteLine("info: {0} trades processed", trades.Count());

        }
    }
}
