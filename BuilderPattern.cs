using System;

namespace DesignPatterns
{
    public interface IAirCraft
    {
        public void SetEngine(string engine);
        public void SetWings(string wings);
        public void SetCockpit(string cockpit);
        public void SetBathrooms(string bathrooms);
    }

    public class AirCraft : IAirCraft
    {
        private string engine;
        private string wings;
        private string cockpit;
        private string bathrooms;

        public void SetCockpit(string cockpit)
        {
            this.cockpit = cockpit;
        }

        public string GetCockpit()
        {
            return this.cockpit;
        }

        public void SetEngine(string engine)
        {
            this.engine = engine;
        }

        public string GetEngine()
        {
            return this.engine;
        }

        public void SetWings(string wings)
        {
            this.wings = wings;
        }

        public string GetWings()
        {
            return this.wings;
        }

        public void SetBathrooms(string bathrooms)
        {
            this.bathrooms = bathrooms;
        }

        public string GetBathrooms()
        {
            return this.bathrooms;
        }
    }


    public interface IAirCraftBuilder
    {
        public void BuildEngine();
        public void BuildWings();
        public void BuildCockpit();
        public void BuildBathrooms();
        public AirCraft GetAirCraft();
    }

    public class Boeing747Builder : IAirCraftBuilder
    {
        private AirCraft airCraft;

        public Boeing747Builder()
        {
            this.airCraft = new AirCraft();
        }

        public void BuildEngine()
        {
            this.airCraft.SetEngine("boeing engine");
        }

        public void BuildWings()
        {
            this.airCraft.SetWings("boeing wings");
        }

        public void BuildCockpit()
        {
            this.airCraft.SetCockpit("boeing cockpit");
        }

        public void BuildBathrooms()
        {
            this.airCraft.SetBathrooms("boeing bathrooms XD:)");
        }

        public AirCraft GetAirCraft()
        {
            return this.airCraft;
        }
    }

    public class F16Builder : IAirCraftBuilder
    {
        private AirCraft airCraft;

        public F16Builder()
        {
            this.airCraft = new AirCraft();
        }

        public void BuildEngine()
        {
            this.airCraft.SetEngine("F16 Engine");
        }

        public void BuildWings()
        {
            this.airCraft.SetWings("F16 wings");
        }

        public void BuildCockpit()
        {
            this.airCraft.SetCockpit("F16 cockpit");
        }

        public void BuildBathrooms()
        {
            this.airCraft.SetBathrooms("no F16 bathrooms");
        }

        public AirCraft GetAirCraft()
        {
            return this.airCraft;
        }
    }

    public class Director
    {
        IAirCraftBuilder airCraftBuilder;

        public Director(IAirCraftBuilder airCraftBuilder)
        {
            this.airCraftBuilder = airCraftBuilder;
        }

        public AirCraft GetAirCraft()
        {
            return this.airCraftBuilder.GetAirCraft();
        }

        public void ConstructAirCraft(bool isPassenger)
        {
            this.airCraftBuilder.BuildEngine();
            this.airCraftBuilder.BuildCockpit();
            this.airCraftBuilder.BuildWings();
            if (isPassenger)
            {
                this.airCraftBuilder.BuildBathrooms();
            }
        }
    }


    class BuilderPattern
    {
        static void Main(string[] args)
        {
            IAirCraftBuilder airCraftBuilder = new F16Builder();  //can be considered as a specific blueprint for building F16
            Director director = new Director(airCraftBuilder);    //the building specs is passed to the director or engineer for building

            director.ConstructAirCraft(isPassenger: false);       //engineer constructs the aircraft
            AirCraft airCraft1 = director.GetAirCraft();          // the engineer returns the robot after building the aircraft

            Console.WriteLine("Aircraft Constructed: " + airCraft1);
            Console.WriteLine("aircraft engine: " + airCraft1.GetEngine());
            Console.WriteLine("aircraft cockpit: " + airCraft1.GetCockpit());
            Console.WriteLine("aircraft wings: " + airCraft1.GetWings());
            Console.WriteLine("aircraft bathroom: " + airCraft1.GetBathrooms());
        }
    }
}
