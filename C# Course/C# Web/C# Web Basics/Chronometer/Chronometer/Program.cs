using System;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();
            const string end = "exit";
            const string start = "start";
            const string stop = "stop";
            const string reset = "reset";
            const string lap = "lap";
            const string time = "time";
            const string laps = "laps";

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd.Equals(end))
                {
                    break;
                }

                switch (cmd)
                {
                    case start:
                        {
                            chronometer.Start();
                            break;
                        }
                    case stop:
                        {
                            chronometer.Stop();
                            break;
                        }
                    case reset:
                        {
                            chronometer.Reset();
                            break;
                        }
                    case lap:
                        {
                            Console.WriteLine(chronometer.Lap());
                            break;
                        }
                    case laps:
                        {
                            var recordedLaps = chronometer.Laps;
                            if (laps.Length == 0)
                            {
                                Console.WriteLine("Laps: no laps");
                                break;
                            }
                            for (int i = 0; i < recordedLaps.Count; i++)
                            {
                                Console.WriteLine($"{i}. {recordedLaps[i]}");
                            }
                            break;
                        }
                    case time:
                        {
                            Console.WriteLine(chronometer.GetTime);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
