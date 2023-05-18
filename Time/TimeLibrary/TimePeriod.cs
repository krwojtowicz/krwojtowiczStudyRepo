using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public struct TimePeriod
    {
        private readonly long _seconds;
        public long Seconds { get { return _seconds; } }

        public TimePeriod(int hours = 0, int minutes = 0, int seconds = 0)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentOutOfRangeException("Wrong hours, vlaue not in 0-23 range");

            if (minutes < 0 || minutes > 59)
                throw new ArgumentOutOfRangeException("Wrong minutes, value not in 0-59");

            if (seconds < 0 || seconds > 59)
                throw new ArgumentOutOfRangeException("Wrong seconds, value not in 0-59");

            _seconds = hours*3600 + minutes*60 + seconds;
        }


    }
}
