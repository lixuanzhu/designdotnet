using System;

namespace Design.Watch
{
    public static class Util
    {
        public static bool IsSet(DateTime time)
        {
            return time != DateTime.MinValue;
        }
    }
}
