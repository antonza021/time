using System;
using System.Collections.Generic;
using System.Text;

namespace Clock
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public static Time operator +(Time time1, Time time2)
        {
            int totalSeconds = time1.Seconds + time2.Seconds;
            int carryMinutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            int totalMinutes = time1.Minutes + time2.Minutes + carryMinutes;
            int carryHours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            int hours = time1.Hours + time2.Hours + carryHours;

            return new Time(hours, minutes, seconds);
        }

        public static Time operator -(Time time1, Time time2)
        {
            int totalSeconds = time1.Seconds - time2.Seconds;
            int borrowMinutes = 0;
            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                borrowMinutes = 1;
            }

            int totalMinutes = time1.Minutes - time2.Minutes - borrowMinutes;
            int borrowHours = 0;
            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                borrowHours = 1;
            }

            int hours = time1.Hours - time2.Hours - borrowHours;
            if (hours < 0)
            {
                throw new ArgumentException("Time difference results in negative time");
            }

            return new Time(hours, totalMinutes, totalSeconds);
        }

        public static bool operator ==(Time time1, Time time2)
        {
            if (Object.ReferenceEquals(time1, time2))
            {
                return true;
            }

            if ((object)time1 == null || (object)time2 == null)
            {
                return false;
            }

            return time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds == time2.Seconds;
        }

        public static bool operator !=(Time time1, Time time2)
        {
            return !(time1 == time2);
        }

        public static bool operator <(Time time1, Time time2)
        {
            if (time1.Hours < time2.Hours)
            {
                return true;
            }
            else if (time1.Hours == time2.Hours && time1.Minutes < time2.Minutes)
            {
                return true;
            }
            else if (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds < time2.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Time time1, Time time2)
        {
            if (time1.Hours > time2.Hours)
            {
                return true;
            }
            else if (time1.Hours == time2.Hours && time1.Minutes > time2.Minutes)
            {
                return true;
            }
            else if (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes && time1.Seconds > time2.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(Time time1, Time time2)
        {
            return time1 == time2 || time1 < time2;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            return time1 == time2 || time1 > time2;
        }

        public static Time operator ++(Time time)
        {
            int totalSeconds = time.Seconds + 1;
            int carryMinutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            int totalMinutes = time.Minutes + carryMinutes;
            int carryHours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            int hours = time.Hours + carryHours;

            return new Time(hours, minutes, seconds);
        }

        public static Time operator --(Time time)
        {
            int totalSeconds = time.Seconds - 1;
            int borrowMinutes = 0;
            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                borrowMinutes = 1;
            }

            int totalMinutes = time.Minutes - borrowMinutes;
            int borrowHours = 0;
            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                borrowHours = 1;
            }

            int hours = time.Hours - borrowHours;
            if (hours < 0)
            {
                throw new ArgumentException("Time difference results in negative time");
            }

            return new Time(hours, totalMinutes, totalSeconds);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Time time = obj as Time;
            if ((object)time == null)
            {
                return false;
            }

            return this == time;
        }

        public override int GetHashCode()
        {
            return this.Hours.GetHashCode() ^ this.Minutes.GetHashCode() ^ this.Seconds.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", this.Hours, this.Minutes, this.Seconds);
        }
    }
}