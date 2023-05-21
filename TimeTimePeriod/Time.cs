using System;
namespace TimeTimePeriod;

public struct Time :IEquatable<Time> , IComparable<Time>
{
    /// <summary>
    /// gets the hours
    /// </summary>
    public byte Hours { get; }
    /// <summary>
    /// gets the minutes
    /// </summary>
    public byte Minutes { get ; }

    /// <summary>
    /// gets the seconds
    /// </summary>
    public byte Seconds { get; }
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    /// <param name="minutes"> value of the minutes between 0 and 59</param>
    /// <param name="seconds">value of the seconds between 0 and 59</param>
    /// <exception cref="ArgumentException"></exception>
    public Time(byte hours, byte minutes, byte seconds)
    {
        if (hours > 24 || minutes > 60 || seconds > 60) throw new ArgumentException("invalid format");

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;

    }
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    /// <param name="minutes"> value of the minutes between 0 and 59</param>
    public Time(byte hours, byte minutes) : this(hours, minutes, 0){}
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    public Time(byte hours) : this(hours, 0, 0){}
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="timeString">String represantion of time. String should be in HH:MM:SS</param>
    /// <exception cref="ArgumentException">string format is invalid</exception>
    public Time(string timeString)
    {
        var data = timeString.Split(":");
        if (data.Length != 3) throw new ArgumentException("invalid format");
        if (
            byte.TryParse(data[0], out byte hours) &&
            byte.TryParse(data[1], out byte minutes) &&
            byte.TryParse(data[2], out byte seconds) &&
            hours < 24 && minutes < 60 && seconds < 60
        )
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        else
        {
            throw new ArgumentException("invalid format");
        }

    }
    /// <summary>
    /// convert to string 
    /// </summary>
    /// <returns>string representation time</returns>
    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
    /// <summary>
    /// checks the current Time object is equal to another Time object.    
    /// </summary>
    /// <param name="other">compare the objects</param>
    /// <returns> true when objects are equal</returns>

    public bool Equals(Time other)
    {
        return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
    }
    /// <summary>
    /// checks the current Time object is equal to another Time object.
    /// </summary>
    /// <param name="obj">compare the objects</param>
    /// <returns> true when objects are equal</returns>

    public override bool Equals(object? obj)
    {
        return obj is Time other && Equals(other);
    }
    /// <summary>
    /// Gets the hash code 
    /// </summary>
    /// <returns>The hash code</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }
    /// <summary>
    /// Compares the time object
    /// </summary>
    /// <param name="other">the time object to compare with the current object</param>
    /// <returns>
    /// returns a negative number if the current object is less
    /// returns zero if they are equal
    /// returns a postive number if the current object is greater
    /// </returns>
    public int CompareTo(Time other)
    {
        if (Hours != other.Hours) return Hours.CompareTo(other.Hours);
         if (Minutes != other.Minutes) return Minutes.CompareTo(other.Minutes);
         return Seconds.CompareTo(other.Seconds);
        
    }
    /// <summary>
    /// Checks if two object are equal
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if the objects are equal else returns false </returns>
    public static bool operator ==(Time t1, Time t2)
    {
        return t1.Equals(t2);
    }
    /// <summary>
    /// Checks if two object are  not equal
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if the objects are not  equal else returns false </returns>
    public static bool operator !=(Time t1, Time t2)
    {
        return !(t1.Equals(t2));
    }
    /// <summary>
    /// Checks if first object is smaller
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if first object is smaller else false </returns>
    public static bool operator <(Time t1, Time t2)
    {
        return t1.CompareTo(t2) < 0 ;
    }
    /// <summary>
    /// Checks if first object is smaller or equal
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if first object is smaller or equal else false </returns>
    public static bool operator <=(Time t1, Time t2)
    {
        return t1.CompareTo(t2) <= 0 ;
    }
    /// <summary>
    /// Checks if first object is greater
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if first object is greater else false </returns>
    public static bool operator >(Time t1, Time t2)
    {
        return t1.CompareTo(t2) > 0 ;
    }
    /// <summary>
    /// Checks if first object is greater or equal
    /// </summary>
    /// <param name="t1"> first object to compare</param>
    /// <param name="t2"> second object to compare</param>
    /// <returns> true if first object is greater  or equal else false </returns>
    public static bool operator >=(Time t1, Time t2)
    {
        return t1.CompareTo(t2) >= 0 ;
    }
    /// <summary>
    /// Add the time and timePeriode object
    /// </summary>
    /// <param name="time">time object</param>
    /// <param name="timePeriod">timePeriod object</param>
    /// <returns>new time representive</returns>
    public static Time operator +(Time time, TimePeriod timePeriod)
    {
        var totalSeconds = ((time.Hours * 3600 + time.Minutes * 60 + time.Seconds) + timePeriod.TotalSeconds) % (24 * 3600);
        return new Time((byte)(totalSeconds / 3600), (byte)((totalSeconds % 3600) / 60), (byte)(totalSeconds % 60));
    }
    /// <summary>
    /// Minus the time and timePeriode object
    /// </summary>
    /// <param name="time">time object</param>
    /// <param name="timePeriod">timePeriod object</param>
    /// <returns>new time representive</returns>
    public static Time operator -(Time time, TimePeriod timePeriod)
    {
        long timeTotal = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
        long totalSeconds = 0;
        if (timeTotal > timePeriod.TotalSeconds) totalSeconds = timeTotal - timePeriod.TotalSeconds;
        else totalSeconds = timePeriod.TotalSeconds - timeTotal;


            return new Time((byte)(totalSeconds / 3600), (byte)((totalSeconds % 3600) / 60), (byte)(totalSeconds % 60));
    }
}