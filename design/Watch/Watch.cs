using System;
using System.IO;
using System.Threading;

namespace Design.Watch
{
    public class Watch
    {
        private const string fileName = "timers.txt";
        private const int totalMode = 3;
        private readonly IWatch[] watch;
        private string button = string.Empty;
        private int mode;

        public Watch()
        {
            watch = new IWatch[] {
                        new MyStopWatch(),
                        new MyTimer(),
                        new MyClock()};
            mode = 0;
        }

        public static void Test()
        {
            using (File.Create(fileName));
            Watch test = new Watch();
            string button;
            while (true)
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    button = sr.ReadLine();
                }

                if (!string.IsNullOrEmpty(button))
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.WriteLine(string.Empty);
                    }

                    if (button == "A")
                    {
                        test.mode = (test.mode + 1) % totalMode;
                    }
                    else if (button.Equals("B"))
                    {
                        test.watch[test.mode].PressButtonB();
                    }
                    else
                    {
                        Console.WriteLine("done!");
                        return;
                    }
                }
                Console.Write("\r                           \r");
                Console.Write(test.watch[test.mode].Display());
                Thread.Sleep(100);
            }
        }
    }
}
