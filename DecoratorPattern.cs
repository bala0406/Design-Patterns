using System;
using System.Collections.Generic;

public interface IAircraft
{
    void Fly();
    void Land();
    float GetWeight();
}

public class Boeing747 : IAircraft
{
    float baseWeight = 100f;

    public void Fly()
    {
        Console.WriteLine("Boeing747 flying");
    }

    public float GetWeight()
    {
        return baseWeight;
    }

    public void Land()
    {
        Console.WriteLine("Boeing747 landed");
    }
}

public class F16 : IAircraft
{
    float baseWeight = 60f;

    public void Fly()
    {
        Console.WriteLine("F16 flying");
    }

    public float GetWeight()
    {
        return baseWeight;
    }

    public void Land()
    {
        Console.WriteLine("F16 landed");
    }
}


// decorator
public abstract class AircraftDecorator : IAircraft
{
    public abstract void Fly();
    public abstract float GetWeight();
    public abstract void Land();
}

// concrete decorator
public class LuxuryFitting : AircraftDecorator
{
    private float weight = 20f;
    IAircraft aircraft;

    public LuxuryFitting(IAircraft aircraft)
    {
        this.aircraft = aircraft;
    }

    public override void Fly()
    {
        this.aircraft.Fly();
    }

    public override float GetWeight()
    {
        return this.weight + this.aircraft.GetWeight();
    }

    public override void Land()
    {
        this.aircraft.Land();
    }
}

// concrete decorator
public class BulletProofFitting : AircraftDecorator
{
    private float weight = 10f;
    IAircraft aircraft;

    public BulletProofFitting(IAircraft aircraft)
    {
        this.aircraft = aircraft;
    }

    public override void Fly()
    {
        this.aircraft.Fly();
    }

    public override float GetWeight()
    {
        return this.weight + this.aircraft.GetWeight();
    }

    public override void Land()
    {
        this.aircraft.Land();
    }
}

public class DecoratorPattern
{
    public static void Main(String[] args)
    {
        List<IAircraft> aircrafts = new List<IAircraft>();

        IAircraft simpleBoeing747 = new Boeing747();
        IAircraft luxuryBoeing747 = new LuxuryFitting(simpleBoeing747);
        aircrafts.Add(luxuryBoeing747);

        IAircraft simpleF16 = new F16();
        IAircraft bulletProofF16 = new BulletProofFitting(simpleF16);
        aircrafts.Add(bulletProofF16);

        foreach (IAircraft aircraft in aircrafts)
        {
            aircraft.Fly();
            aircraft.Land();
            Console.WriteLine($"The final weight of the aircraft is {aircraft.GetWeight()}");
        }
    }
}
