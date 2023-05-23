using System;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace Time
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        public byte Hours { get { return _hours; } }
        public byte Minutes { get { return _minutes; } }
        public byte Seconds { get { return _seconds; } }

        /// <summary>
        /// reprezentuje czas (godzina minuta i sekunda) złożony z parametrów typu byte
        /// </summary>
        /// <param name="hour"> zakres parametru 0-23</param>
        /// <param name="minute">zakres parametru 0-59</param>
        /// <param name="second">zakres parametru 0-59</param>
        public Time(byte hour = 0, byte minute = 0, byte second = 0)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException("Wrong hours, vlaue not in 0-23 range");
            else
                _hours = hour;

            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("Wrong minutes, value not in 0-59");
            else
                _minutes = hour;

            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException("Wrong seconds, value not in 0-59");
            else
                _seconds = second;
        }

        /// <summary>
        /// Tworzy nowy element typu Time z podanego stringa
        /// </summary>
        /// <param name="time">format: "hh:mm:ss"</param>
        public Time(string time)
        {
            if (time == "" || time == null)
                throw new ArgumentNullException("Given time cannot be null");

            string[] timeArr = time.Split(':');

            if (timeArr.Length != 3)
                throw new ArgumentException("Given wrong format (expected hh:mm:ss)");

            byte hour = byte.Parse(timeArr[0]);
            byte minute = byte.Parse(timeArr[1]);
            byte second = byte.Parse(timeArr[2]);

            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException("Wrong hours, vlaue not in 0-23 range");
            else
                _hours = hour;

            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("Wrong minutes, value not in 0-59");
            else
                _minutes = hour;

            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException("Wrong seconds, value not in 0-59");
            else
                _seconds = second;
        }

        /// <summary>
        /// reprezentuje strukturę Time w postaci string 
        /// </summary>
        /// <returns>hh:mm:ss</returns>
        public override string ToString()
        {
            return $"{_hours}:{_minutes}:{_seconds}";
        }

        /// <summary>
        /// Metoda equals porównująca ze sobą dwa obiekty typu time
        /// </summary>
        ///  /// <param name="other"> obiekt typu time z którym chcemy porównać obecny obiekt</param>
        /// <returns>true jeżeli obiekty są sobie równe oraz false jeżeli nie są sobie równe</returns>
        public bool Equals(Time other)
        {
            if (Object.ReferenceEquals(this, other)) return true;

            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds)
                return true;
            else
                return false;
        }

        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj);
        //}

        public static bool Equals(Time time1, Time time2)
        {
            return time1.Equals(time2);
        }

        public override int GetHashCode()
        {
            return (Hours, Minutes, Seconds).GetHashCode();
        }

        public int CompareTo(Time other)
        {
            int t1 = this.Hours * 3600 + this.Minutes * 60 + this.Seconds ;

            int t2 = other.Hours * 3600 + other.Minutes * 60 + other.Seconds ;

            return t1.CompareTo(t2);
        }

        public Time Plus(TimePeriod other)
        {
            long second = this.Hours * 3600 + this.Minutes * 60 + this.Seconds + other.Seconds;
            byte hours = Convert.ToByte(second / 3600);
            byte minutes = Convert.ToByte((second - hours * 3600) / 60);
            byte seconds = Convert.ToByte(second - hours * 3600 - minutes * 60);
            return new Time(hours, minutes, seconds);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return !t1.Equals(t2);
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }
       

       
    }

}
