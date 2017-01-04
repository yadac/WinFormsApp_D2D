using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class Startup
    {
        public static void Main()
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SOLIDConcreate.trades.txt");

            ILogger logger = new Log4NetLoggerAdapter();
            var tradeValidator = new SimpleTradeValidator(logger);
            var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);

            TradeProcessor tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();
        }
    }
}
