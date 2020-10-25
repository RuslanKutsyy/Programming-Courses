using SISServer.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace SISServer
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch sw;
        private const string timeFormat = "mm\\:ss\\.ffff";
        public List<string> Laps { get; }

        public Chronometer()
        {
            Laps = new List<string>();
            sw = new Stopwatch();
        }
        public string GetTime => sw.Elapsed.ToString(timeFormat);

        public string Lap()
        {
            string lap = sw.Elapsed.ToString(timeFormat);
            this.Laps.Add(lap);
            
            return lap;
        }

        public void Reset()
        {
            sw.Reset();
            this.Laps.Clear();
        }

        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
        }
    }
}