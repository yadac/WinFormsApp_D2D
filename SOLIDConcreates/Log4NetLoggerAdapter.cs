using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;
using log4net;

namespace SOLIDConcreates
{
    class Log4NetLoggerAdapter : ILogger
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
