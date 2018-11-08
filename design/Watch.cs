using System;
using System.IO;
using System.Threading;

namespace Design
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
            using (File.Create(fileName));
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

    public interface IWatch
    {
        string Display();
        void PressButtonB();
    }

    public class MyStopWatch : IWatch
    {
        private DateTime start;
        private DateTime finish;

        public MyStopWatch()
        {
            this.start = DateTime.MinValue;
            this.finish = DateTime.MinValue;
        }

        public string Display()
        {
            if (start == DateTime.MinValue)
            {
                return "0";
            }
            if (finish == DateTime.MinValue)
            {
                return DateTime.Now.Subtract(start).Seconds.ToString();
            }
            return finish.Subtract(start).Seconds.ToString();
        }

        public void PressButtonB()
        {
            if (!Util.IsSet(start) && !Util.IsSet(finish))
            {
                start = DateTime.Now;
                return;
            }
            if (Util.IsSet(start) && !Util.IsSet(finish))
            {
                finish = DateTime.Now;
                return;
            }
            if (Util.IsSet(start) && Util.IsSet(finish))
            {
                start = DateTime.MinValue;
                finish = DateTime.MinValue;
            }
        }
    }

    public class MyTimer : IWatch
    {
        private DateTime start;
        private int initSeconds;
        private int remainSeconds;

        public MyTimer()
        {
            start = DateTime.MinValue;
            initSeconds = 0;
            remainSeconds = 0;
        }

        public string Display()
        {
            if (!Util.IsSet(start))
            {
                return "0";
            }
            if (remainSeconds > 0)
            {
                remainSeconds = initSeconds - DateTime.Now.Subtract(start).Seconds;
                return remainSeconds.ToString();
            }

            return "0";
        }

        public void PressButtonB()
        {
            start = DateTime.Now;
            initSeconds = remainSeconds + 4;
            remainSeconds = initSeconds;
        }
    }

    public class MyClock : IWatch
    {
        public string Display()
        {
            return DateTime.Now.ToString();
        }

        public void PressButtonB()
        {
        }
    }

    public static class Util
    {
        public static bool IsSet(DateTime time)
        {
            return time != DateTime.MinValue;
        }
    }

}
