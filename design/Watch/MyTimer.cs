using System;

namespace Design.Watch
{
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
}
