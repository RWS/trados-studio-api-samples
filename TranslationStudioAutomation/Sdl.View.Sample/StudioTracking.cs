using Sdl.Desktop.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sdl.View.Sample
{
    public sealed class StudioTracking
    {
        #region Singleton implementation

        private StudioTracking()
        {
        }

        public static StudioTracking Instance
        {
            get { return _lazyInstance.Value; }
        }

        private static readonly Lazy<StudioTracking> _lazyInstance = new Lazy<StudioTracking>(() => new StudioTracking());

        #endregion

        public Stopwatch GetViewWatch<T>()
            where T : AbstractViewController
        {
            Stopwatch watch;
            if (!_viewsTrakingDictionary.TryGetValue(typeof(T), out watch))
            {
                watch = Stopwatch.StartNew();
                _viewsTrakingDictionary.Add(typeof(T), watch);
            }

            return watch;
        }

        private readonly Dictionary<Type, Stopwatch> _viewsTrakingDictionary = new Dictionary<Type, Stopwatch>();
    }
}
