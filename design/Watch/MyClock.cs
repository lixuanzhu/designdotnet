using System;

namespace Design.Watch
{
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
}
