using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music song = new Music("Linkin Park", "Meteora", 3, 67);
            StreamProgressInfo progress = new StreamProgressInfo(song);
            Console.WriteLine(progress.CalculateCurrentPercent());
        }
    }
}
