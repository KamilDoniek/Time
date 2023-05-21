namespace TimeTimePeriod;

class Program
{
    static void Main(string[] args)
    {
        var t1 = new Time(15, 2, 44);
        var t2 = new Time(15, 2, 44);
        var t3 = new Time(5);
        var t4 = new Time("22:13:22");
        
        Console.WriteLine(t1.Equals(t2));
        Console.WriteLine(t3.Equals(t4));
        Console.WriteLine(t3.Equals(t2));

        Console.WriteLine();

        Console.WriteLine($"{t1.ToString()}>{t2.ToString()}  {t1 > t2} ");
        Console.WriteLine($"{t1.ToString()}<{t3.ToString()}  {t1 < t3} ");
        Console.WriteLine($"{t1.ToString()}>={t2.ToString()}  {t1 >= t2} ");
        Console.WriteLine($"{t1.ToString()}<={t2.ToString()}  {t1 <= t2} ");
        Console.WriteLine($"{t3.ToString()}<={t4.ToString()}  {t3 <= t4} ");

        
        Console.WriteLine();

        var tP = new TimePeriod(22, 10, 33);
        Console.WriteLine();
   
        Console.WriteLine($" {t4.ToString()} + {tP.ToString()} {t4 + tP}");
        Console.WriteLine($" {t4.ToString()} - {tP.ToString()} {t4 - tP}");
        
        Console.WriteLine();
        
        Console.WriteLine("TIME PERIOD:");
        
        var tP1 = new TimePeriod(12,22,33);
        var tP2 = new TimePeriod(10,33,23);
        
        Console.WriteLine(tP1.ToString());
        Console.WriteLine(tP2.ToString());
        
        Console.WriteLine();
        
        Console.WriteLine($"{tP1.ToString()} + {tP2.ToString()} {tP1 + tP2}");
        Console.WriteLine($"{tP1.ToString()} - {tP2.ToString()} {tP1 - tP2}");
        
    }
}