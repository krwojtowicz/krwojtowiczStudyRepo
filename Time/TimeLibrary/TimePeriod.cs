using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long _seconds;
        public long Seconds { get { return _seconds; } }

        /// <summary>
        /// reprezentuje przedział czasu (godzina minuta i sekunda) przechowywany jako ilość sekund w typie long
        /// </summary>
        /// <param name="hour"> zakres parametru od 0 w górę</param>
        /// <param name="minute">zakres parametru 0-59</param>
        /// <param name="second">zakres parametru 0-59</param>
        public TimePeriod(int hours = 0, int minutes = 0, int seconds = 0)
        {
            if(hours < 0) throw new ArgumentOutOfRangeException("Wrong hour, vallue cannot be less than 0");

            if (minutes < 0 || minutes > 59)
                throw new ArgumentOutOfRangeException("Wrong minutes, value not in 0-59");

            if (seconds < 0 || seconds > 59)
                throw new ArgumentOutOfRangeException("Wrong seconds, value not in 0-59");

            _seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(long seconds)
        {
            if (seconds < 0) throw new ArgumentException("Given seconds cannot be less than 0");
            _seconds = seconds;
        }

        public TimePeriod(string time)
        {
            if (time == "" || time == null)
                throw new ArgumentNullException("Given time cannot be null or empty");

            string[] timeArr = time.Split(':');

            if (timeArr.Length != 3) throw new ArgumentException("Wrong format");

            byte hour = byte.Parse(timeArr[0]);
            byte minute = byte.Parse(timeArr[1]);
            byte second = byte.Parse(timeArr[2]);

            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException("Wrong minutes, value not in 0-59");

            if (second < 0 || second > 59)
                throw new ArgumentOutOfRangeException("Wrong seconds, value not in 0-59");

            _seconds = hour * 3600 + minute * 60 + second;
        }

        public TimePeriod(Time t1, Time t2)
        {
            if (t1 > t2)
                _seconds = (t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds) - (t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds);
            else
                _seconds = (t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds) - (t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds);
        }

        public override string ToString()
        {
            long hours = _seconds / 3600;
            long minutes = (_seconds - hours * 3600 ) / 60;
            long seconds = _seconds - hours * 3600 - minutes * 60;
            return $"{hours }:{ minutes }:{seconds}";
        }

        public bool Equals(TimePeriod other)
        {
            if (Object.ReferenceEquals(this, other)) return true;

            if (this.Seconds == other.Seconds)
                return true;
            else
                return false;
        }

        //public override bool Equals(object obj)
        //{
        //    return this.Equals(obj);
        //}

        public static bool Equals(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }

        public override int GetHashCode()
        {
            return (_seconds).GetHashCode();
        }

        public TimePeriod Plus(TimePeriod other)
        {
            return new TimePeriod(this.Seconds + other.Seconds);
        }
        public static TimePeriod Plus(TimePeriod t1, TimePeriod t2)
        {
            return t1.Plus(t2);
        }
        public TimePeriod Minus(TimePeriod other)
        {
            if (this.Seconds - other.Seconds < 0) throw new ArgumentException("Nie można wykonać takiej operacji (odjęcie dłuższego od krótszego)");

            return new TimePeriod(this.Seconds - other.Seconds);
        }
        public static TimePeriod Minus(TimePeriod t1, TimePeriod t2)
        {
            return t1.Minus(t2);
        }
        public int CompareTo(TimePeriod other)
        {
            return _seconds.CompareTo(other.Seconds);
        }
        public static bool operator ==(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(TimePeriod t1, TimePeriod t2)
        {
            return !t1.Equals(t2);
        }

        public static bool operator <(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) >= 0;
        }
        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2)
        {
            return Plus(t1, t2);
        }
        public static TimePeriod operator -(TimePeriod t1, TimePeriod t2)
        {
            return Minus(t1, t2);
        }

    }
}
