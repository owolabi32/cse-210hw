using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; private set; }
    public int DurationInMinutes { get; private set; }

    protected Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string activityType = this.GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{Date.ToString("dd MMM yyyy")} {activityType} ({DurationInMinutes} min) - Distance: {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}

public class Running : Activity
{
    public double DistanceInKm { get; private set; }

    public Running(DateTime date, int durationInMinutes, double distanceInKm) 
        : base(date, durationInMinutes)
    {
        DistanceInKm = distanceInKm;
    }

    public override double GetDistance()
    {
        return DistanceInKm;
    }

    public override double GetSpeed()
    {
        return (DistanceInKm / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationInMinutes / DistanceInKm;
    }
}

public class Cycling : Activity
{
    public double AverageSpeedInKph { get; private set; }

    public Cycling(DateTime date, int durationInMinutes, double averageSpeedInKph) 
        : base(date, durationInMinutes)
    {
        AverageSpeedInKph = averageSpeedInKph;
    }

    public override double GetDistance()
    {
        return (AverageSpeedInKph / 60) * DurationInMinutes;
    }

    public override double GetSpeed()
    {
        return AverageSpeedInKph;
    }

    public override double GetPace()
    {
        return 60 / AverageSpeedInKph;
    }
}

public class Swimming : Activity
{
    public int NumberOfLaps { get; private set; }

    public Swimming(DateTime date, int durationInMinutes, int numberOfLaps) 
        : base(date, durationInMinutes)
    {
        NumberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return NumberOfLaps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 4), 45, 20),
            new Swimming(new DateTime(2022, 11, 5), 20, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}