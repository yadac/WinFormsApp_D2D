using System.Diagnostics;

namespace Composite
{
    public class StopwatchAdapter : IStopwatch
    {
        private readonly Stopwatch stopwatch;

        public StopwatchAdapter(Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
        }


        public void Start()
        {
            stopwatch.Start();
        }

        public long Stop()
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            return elapsedMilliseconds;
        }
    }
}