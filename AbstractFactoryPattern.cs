using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    // abstract factory
    public interface IAircraftFactory
    {
        IEngine CreateEngine();
        ICockpit CreateCockpit();
        IWings CreateWings();
    }

    // concrete factory
    public class F16Factory : IAircraftFactory
    {
        public ICockpit CreateCockpit()
        {
            return new F16Cockpit();
        }

        public IEngine CreateEngine()
        {
            return new F16Engine();
        }

        public IWings CreateWings()
        {
            return new F16Wings();
        }
    }

    // concrete factory
    public class Boeing747Factory : IAircraftFactory
    {
        public ICockpit CreateCockpit()
        {
            return new Boeing747Cockpit();
        }

        public IEngine CreateEngine()
        {
            return new Boeing747Engine();
        }

        public IWings CreateWings()
        {
            return new Boeing747Wings();
        }
    }

    // abstract product
    public interface IEngine
    {
        public void Build();
        public void Run();
    }

    // concrete product
    public class F16Engine : IEngine
    {
        public void Build()
        {
            Console.WriteLine("F16 engine built");
        }

        public void Run()
        {
            Console.WriteLine("F16 engine running");
        }
    }

    // concrete product
    public class Boeing747Engine : IEngine
    {
        public void Build()
        {
            Console.WriteLine("Boeing747 engine built");
        }

        public void Run()
        {
            Console.WriteLine("Boeing747 engine running");
        }
    }

    // abstract product
    public interface ICockpit
    {
        public void Build();
    }

    // concrete product
    public class F16Cockpit : ICockpit
    {
        public void Build()
        {
            Console.WriteLine("built F16 cockpit");
        }
    }

    // concrete product
    public class Boeing747Cockpit : ICockpit
    {
        public void Build()
        {
            Console.WriteLine("built boeing747 cockpit");
        }
    }

    // abstract product
    public interface IWings
    {
        public void Build();
    }

    // concrete product
    public class F16Wings : IWings
    {
        public void Build()
        {
            Console.WriteLine("built F16 wings");
        }
    }

    // concrete product
    public class Boeing747Wings : IWings
    {
        public void Build()
        {
            Console.WriteLine("Built Boeing747 wings");
        }
    }


    public class Aircraft
    {
        IEngine engine;
        ICockpit cockpit;
        IWings wings;
        IAircraftFactory aircraftFactory;

        public Aircraft(IAircraftFactory aircraftFactory)
        {
            this.aircraftFactory = aircraftFactory;
        }

        private Aircraft MakeAircraft()
        {
            //building engine
            engine = aircraftFactory.CreateEngine();
            engine.Build();
            engine.Run();

            //building cockpit
            cockpit = aircraftFactory.CreateCockpit();
            cockpit.Build();

            //building wings
            wings = aircraftFactory.CreateWings();
            wings.Build();

            return this;
        }

        private void Taxi()
        {
            Console.WriteLine("Taxing on runway");
        }

        private void Fly()
        {
            Console.WriteLine("Flying");
        }

        public void BuildAndFly()
        {
            this.MakeAircraft();
            this.Taxi();
            this.Fly();
        }
    }

    class AbstractFactoryPattern
    {
        // client code 
        public static void Main(string[] args)
        {
            IAircraftFactory f16Factory = new F16Factory();
            Aircraft f16 = new Aircraft(f16Factory);


            IAircraftFactory boeing747Factory = new Boeing747Factory();
            Aircraft boeing747 = new Aircraft(boeing747Factory);

            List<Aircraft> aircrafts = new List<Aircraft>();
            aircrafts.Add(f16);
            aircrafts.Add(boeing747);


            foreach (Aircraft aircraft in aircrafts)
            {
                aircraft.BuildAndFly();
            }
        }
    }
}
