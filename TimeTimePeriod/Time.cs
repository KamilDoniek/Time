namespace TimeTimePeriod;

public struct Time :IEquatable<Time> , IComparable<Time>
{
    public byte Hours
    {
        get => Hours;
        private init => Hours = value;
    }

    public byte Minutes
    {
        get => Minutes;
       private init => Minutes = value;
    }

    public byte Seconds
    {
        get => Seconds;
        private init => Seconds = value;
    }

    public Time(byte hours, byte minutes, byte seconds)
    {
        if (hours > 24 || minutes > 60 || seconds > 60) throw new ArgumentException("invalid format");

        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;

    }
    public Time(byte hours, byte minutes) : this(hours, minutes, 0){}

    public Time(byte hours) : this(hours, 0, 0){}

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

    public override string ToString()
    {
        return $"{Hours}:{Minutes}:{Seconds}";
    }

    public bool Equals(Time other)
    {
        return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
    }

    public override bool Equals(object? obj)
    {
        return obj is Time other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }

    public int CompareTo(Time other)
    {
        if (Hours != other.Hours) return Hours.CompareTo(other.Hours);
         if (Minutes != other.Minutes) return Minutes.CompareTo(other.Minutes);
         return Seconds.CompareTo(other.Seconds);
        
    }
    public static bool operator ==(Time t1, Time t2)
    {
        return t1.Equals(t2);
    }
    public static bool operator !=(Time t1, Time t2)
    {
        return !(t1.Equals(t2));
    }
    public static bool operator <(Time t1, Time t2)
    {
        return t1.CompareTo(t2) < 0 ;
    }
    public static bool operator <=(Time t1, Time t2)
    {
        return t1.CompareTo(t2) <= 0 ;
    }

    public static bool operator >(Time t1, Time t2)
    {
        return t1.CompareTo(t2) > 0 ;
    }
    public static bool operator >=(Time t1, Time t2)
    {
        return t1.CompareTo(t2) >= 0 ;
    }
    // public static Time operator +(Time time, TimePeriod timePeriod)
    // {
    //     var totalSeconds = ((time.Hours * 3600 + time.Minutes * 60 + time.Seconds) + timePeriod.TotalSeconds) % (24 * 3600);
    //     return new Time((byte)(totalSeconds / 3600), (byte)((totalSeconds % 3600) / 60), (byte)(totalSeconds % 60));
    // }

}