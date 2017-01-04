using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite;
using log4net;

namespace Composite
{
    public class Log4NetLoggerAdapter : ILogger
    {
        private ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogWarning(string message, params object[] args)
        {
            logger.Warn(string.Format(message, args));
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            logger.Info(string.Format(message, args));
        }

        public void LogError(string message, params object[] args)
        {
            logger.Error(string.Format(message, args));
        }
    }
}
