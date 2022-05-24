using System;
using System.Diagnostics;

namespace Sdl.StudioInitializer.Sample
{
    public static class StudioTracking
    {
        private static Stopwatch _tracker;

        public static void Start()
        {
            _tracker = Stopwatch.StartNew();
        }

        public static TimeSpan? Elapsed
        {
            get { return _tracker?.Elapsed; }
        }

        public static void Stop()
        {
            _tracker?.Stop();
            _tracker = null;
        }
    }
}
