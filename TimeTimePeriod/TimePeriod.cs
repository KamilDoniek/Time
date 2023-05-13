namespace TimeTimePeriod;

public struct TimePeriod
{
    private  long  TotalSeconds;

    public TimePeriod(int hours , int minutes, int seconds)
    {
        if (hours < 0 || minutes < 0 || minutes > 60 || seconds < 0 || seconds > 60) throw new ArgumentException("invalid data");
       
        TotalSeconds = hours*3600+minutes*60+seconds;
    }

    public TimePeriod(int hours, int minutes) : this(hours, minutes, 0) { }
    public TimePeriod(int hours) : this(hours, 0, 0) { }

}