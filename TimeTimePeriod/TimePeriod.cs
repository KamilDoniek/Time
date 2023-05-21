namespace TimeTimePeriod;

public struct TimePeriod:IEquatable<TimePeriod>,IComparable<TimePeriod>
{
    /// <summary>
    /// Gets the total seconds in the time period 
    /// </summary>
    public long  TotalSeconds;

    /// <summary>
    /// constructor 
    /// </summary>
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    /// <param name="minutes"> value of the minutes between 0 and 59</param>
    /// <param name="seconds">value of the seconds between 0 and 59</param>
    /// <exception cref="ArgumentException">invalid data</exception>
    public TimePeriod(long hours , long minutes , long seconds)
    {
        if (hours < 0 || minutes < 0 || minutes > 60 || seconds < 0 || seconds > 60) throw new ArgumentException("invalid data");
       
        TotalSeconds = hours*3600+minutes*60+seconds;
    }
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    /// <param name="minutes"> value of the minutes between 0 and 59</param>
    
    public TimePeriod(long hours, long minutes) : this(hours, minutes, 0) { }
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="hours">Value of the hours between 0 and 24</param>
    public TimePeriod(long hours) : this(hours, 0, 0) { }
    /// <summary>
    /// constructor 
    /// </summary>
    /// <param name="timeString">String represantion of time period.</param>
    /// <exception cref="ArgumentException">string format is invalid</exception>
    public  TimePeriod(string TimePeriodString)
    {
        var parts = TimePeriodString.Split(":");
        if (parts.Length != 3) throw new ArgumentException("invalid data");
        if (!long.TryParse( parts[0],out long hours ) || !long.TryParse(parts[1],out long minutes) || !long.TryParse(parts[2], out long seconds))
        {
            throw new ArgumentException("invalid data");

        }
        TotalSeconds = hours * 3600 + minutes * 60 + seconds;
    }
    /// <summary>
    /// convert to string 
    /// </summary>
    /// <returns>string representation time period</returns>
    public override string ToString()
    {
        return $"{TotalSeconds / 3600}:{(TotalSeconds / 60) % 60}:{TotalSeconds % 60}";
    } 
    /// <summary>
    /// checks the current TimePeriod object is equal to another Time object.    
    /// </summary>
    /// <param name="other">compare the objects</param>
    /// <returns> true when objects are equal</returns>

    public bool Equals(TimePeriod other)
    {
        return TotalSeconds == other.TotalSeconds;
    }
    /// <summary>
    /// checks the current TimePeriod object is equal to another Time object.    
    /// </summary>
    /// <param name="obj">compare the objects</param>
    /// <returns> true when objects are equal</returns>
    public override bool Equals(object? obj)
    {
        return obj is TimePeriod other && Equals(other);
    }
    /// <summary>
    /// Gets the hash code 
    /// </summary>
    /// <returns>The hash code</returns>
    public override int GetHashCode()
    {
        return TotalSeconds.GetHashCode();
    }
    /// <summary>
    /// Compares the time period object
    /// </summary>
    /// <param name="other">the time period object to compare with the current object</param>
    /// <returns>
    /// returns a negative number if the current object is smaller 
    /// returns zero if they are equal
    /// returns a postive number if the current object is greater
    /// </returns>
    public int CompareTo(TimePeriod other)
    {
        return TotalSeconds.CompareTo(other.TotalSeconds);
    }
    /// <summary>
    /// Checks if two object are equal
    /// </summary>
    /// <param name="Time1">first object to compare</param>
    /// <param name="Time2">second object to compare</param>
    /// <returns>true if the objects are equal else returns false</returns>
    public  static bool operator ==(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.Equals(Time2);
    }
    /// <summary>
    /// Checks if two object are  not equal
    /// </summary>
    /// <param name="Time1">first object to compare</param>
    /// <param name="Time2">second object to compare</param>
    /// <returns>true if the objects are not equal else returns false</returns>
    public  static bool operator !=(TimePeriod Time1, TimePeriod Time2)
    {
        return !Time1.Equals(Time2);
    }
    /// <summary>
    /// Checks if first object is smaller
    /// </summary>
    /// <param name="time1"> first object to compare</param>
    /// <param name="time2"> second object to compare</param>
    /// <returns> true if first object is smaller else false </returns>
    public  static bool operator <(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.CompareTo(Time2)<0;;
    }
    /// <summary>
    /// Checks if first object is smaller or equal
    /// </summary>
    /// <param name="time1"> first object to compare</param>
    /// <param name="time2"> second object to compare</param>
    /// <returns> true if first object is smaller or equal else false </returns>
    public  static bool operator <=(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.CompareTo(Time2)<=0;
    }
    /// <summary>
    /// Checks if first object is greater
    /// </summary>
    /// <param name="time1"> first object to compare</param>
    /// <param name="time2"> second object to compare</param>
    /// <returns> true if first object is greater else false </returns>
    public  static bool operator >(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.CompareTo(Time2)>0;
    }
    /// <summary>
    /// Checks if first object is greater or equal
    /// </summary>
    /// <param name="time1"> first object to compare</param>
    /// <param name="time2"> second object to compare</param>
    /// <returns> true if first object is greater  or equal else false </returns>
    public  static bool operator >=(TimePeriod Time1, TimePeriod Time2)
    {
        return  Time1.CompareTo(Time2)>=0;
    }
    
    public TimePeriod Plus(TimePeriod other)
    {
        long total = TotalSeconds + other.TotalSeconds;
        long hours = total / 3600;
        long minutes = (total / 60) % 60;
        long seconds = total % 60;
        
        return new TimePeriod(hours,minutes,seconds);
    }

    public TimePeriod Minus(TimePeriod other)
    {
        long total=0;
        if (TotalSeconds > other.TotalSeconds) total = TotalSeconds - other.TotalSeconds;
        else total = other.TotalSeconds - TotalSeconds;
        
       
        long hours = total / 3600;
        long minutes = (total / 60) % 60;
        long seconds = total % 60;
        
        return new TimePeriod(hours,minutes,seconds);
    }
    /// <summary>
    /// add two objects time period
    /// </summary>
    /// <param name="Time1"> first object</param>
    /// <param name="Time2"> second object</param>
    /// <returns> new time period object</returns>
    public static TimePeriod operator +(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.Plus(Time2);
    }
    /// <summary>
    /// minus two objects time period
    /// </summary>
    /// <param name="Time1"> first object</param>
    /// <param name="Time2"> second object</param>
    /// <returns> new time period object</returns>
    public static TimePeriod operator -(TimePeriod Time1, TimePeriod Time2)
    {
        return Time1.Minus(Time2);
    }
}