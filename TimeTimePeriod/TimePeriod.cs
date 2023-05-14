namespace TimeTimePeriod;

public struct TimePeriod:IEquatable<TimePeriod>,IComparable<TimePeriod>
{
    public long  TotalSeconds;

    public TimePeriod(long hours , long minutes , long seconds)
    {
        if (hours < 0 || minutes < 0 || minutes > 60 || seconds < 0 || seconds > 60) throw new ArgumentException("invalid data");
       
        TotalSeconds = hours*3600+minutes*60+seconds;
    }

    public TimePeriod(long hours, long minutes) : this(hours, minutes, 0) { }
    public TimePeriod(long hours) : this(hours, 0, 0) { }

    public  TimePeriod(string TimePeriodString)
    {
        var parts = TimePeriodString.Split(":");
        if (parts.Length != 3) throw new ArgumentException("invalid data");
        if (!long.TryParse( parts[0],out long hours ) || !long.TryParse(parts[1],out long minutes) || !long.TryParse(parts[3], out long seconds))
        {
            throw new ArgumentException("invalid data");

        }
        TotalSeconds = hours * 3600 + minutes * 60 + seconds;
    }

    public override string ToString()
    {
        return $"{TotalSeconds / 3600}:{(TotalSeconds / 60) % 60}:{TotalSeconds % 60} ";
    }

    public bool Equals(TimePeriod other)
    {
        return TotalSeconds == other.TotalSeconds;
    }

    public override bool Equals(object? obj)
    {
        return obj is TimePeriod other && Equals(other);
    }

    public override int GetHashCode()
    {
        return TotalSeconds.GetHashCode();
    }

    public int CompareTo(TimePeriod other)
    {
        return TotalSeconds.CompareTo(other.TotalSeconds);
    }
    public  static bool operator ==(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.Equels(Time2);
    }
    public  static bool operator !=(TimePeriod Time1, TimePeriod Time2)
    {
        return !Time1.Equels(Time2);
    }
    public  static bool operator <(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1<Time2;
    }
    public  static bool operator <=(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1<=Time2;
    }
    public  static bool operator >(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1>Time2;
    }
    public  static bool operator >=(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1>=Time2;
    }
    public TimePeriod Plus(TimePeriod other)
    {
        return new TimePeriod(TotalSeconds + other.TotalSeconds);
    }
    public static TimePeriod operator +(TimePeriod Time1, TimePeriod Time2)
    {
        return new TimePeriod(Time1.TotalSeconds +Time2.TotalSeconds);
    }
    public static TimePeriod operator -(TimePeriod Time1, TimePeriod Time2)
    {
        return new TimePeriod(Time1.TotalSeconds -Time2.TotalSeconds);
    }
}