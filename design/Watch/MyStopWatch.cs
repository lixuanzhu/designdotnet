using System;

namespace Design.Watch
{
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
}
