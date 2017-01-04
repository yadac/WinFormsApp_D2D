using System;
using log4net;

namespace Composite
{
    public class LoggingStopwatch : IStopwatch
    {
        private readonly IStopwatch decoratedStopwatch;
        private readonly ILogger logger;

        public LoggingStopwatch(IStopwatch decoratedStopwatch)
        {
            this.decoratedStopwatch = decoratedStopwatch;
            logger = new Log4NetLoggerAdapter();
        }

        public void Start()
        {
            decoratedStopwatch.Start();
            logger.LogInfo("stopwatch started ...");
        }

        public long Stop()
        {
            var elapsedMilliseconds = decoratedStopwatch.Stop();
            logger.LogInfo("stopwatch stopped after {0} seconds",
                TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds);
            return elapsedMilliseconds;
        }
    }
}
