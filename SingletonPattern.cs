using System;

namespace SingletonPattern
{
    public class AirForceOne
    {
        //sole instance of the class
        private static AirForceOne instance;
        
        //constructor accessible only to members of the class
        private AirForceOne()
        {
            System.Console.WriteLine("Constructor Called!");
        }

        public static AirForceOne GetInstance()
        {
            if (instance == null)
            {
                instance = new AirForceOne();
            }
            return instance;
        }

        public void Fly()
        {
            Console.WriteLine("AirForce one is Flying!!");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // The below code doesnt work as the AirForceOne class doesnt allow object intialization
            // AirForceOne airForceOne = new AirForceOne();

            //only single instance is alive
            AirForceOne airForceOne = AirForceOne.GetInstance();
            airForceOne.Fly();
        }
    }
}
