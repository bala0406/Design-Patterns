using System;

namespace FactoryMethodPattern
{
    public interface ITransport
    {
        public void Deliver();
    }

    public class Truck : ITransport
    {
        public void Deliver()
        {
            System.Console.WriteLine("Truck - delivered!");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            System.Console.WriteLine("Ship - delivered!");
        }
    }

    //The factory method
    public abstract class Logistics
    {
        //This is the factory method that delegates the creation to its sub classes
        public abstract ITransport CreateTransport();

        public void PlanDelivery()
        {
            //This instantiation doesn't know what type of logistics is going to be instantiated
            // and what type of transport it is going to return
            // It just calls the deliver method over the transport. that's it!
            ITransport transport = CreateTransport();
            transport.Deliver();
        }
    }

    //the delegated class creating the Truck Object
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    //the delegated class creating the Ship Object
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    class FactoryMethodPattern
    {
        public static void Main(String[] args)
        {
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery();

            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery();
        }
    }
}
