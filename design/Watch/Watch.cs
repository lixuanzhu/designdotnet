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
            using (File.Create(fileName)) ;
        }

        public void Run()
        {
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
                        mode = (mode + 1) % totalMode;
                    }
                    else if (button.Equals("B"))
                    {
                        watch[mode].PressButtonB();
                    }
                    else
                    {
                        Console.WriteLine("done!");
                        return;
                    }
                }
                Console.Write("\r                           \r");
                Console.Write(watch[mode].Display());
                Thread.Sleep(100);
            }
        }
    }
}
