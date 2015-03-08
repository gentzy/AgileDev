using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._1_Inheritance
{
    class Program
    {
        public static void Main(string[] args)
        {
            IVehicle car = new ElectricCar();
            IVehicle flyingCar = new FlyingCar();

            BrakeVehicle(car);
            BrakeVehicle(flyingCar);

            //LandFlyingThing(flyingCar);

            LandFlyingThing((IFlyingThing)flyingCar);
        }

        public static void BrakeVehicle(IVehicle vehicle)
        {
            vehicle.Brake();
        }

        public static void LandFlyingThing(IFlyingThing thing)
        {
            thing.Land();
        }
    }

    public interface IFlyingThing
    {
        void Fly(); // if the interface is declared public, all the methods on it are public by default
        void Land();
    }

    public class Airplane : IFlyingThing
    {
        public void Fly()
        {
            Console.WriteLine("Airplane flying");
        }

        public void Land()
        {
            Console.WriteLine("Airplane landing");
        }
    }

    public interface IVehicle
    {
        void Accelerate();
        void Brake();
        void Steer(string direction);
    }

    // This class cannot be instantiated because it is abstract
    public abstract class Car : IVehicle
    {
        public abstract void Accelerate(); // method with no implementation

        public abstract void Brake();

        // Method with an implementation but which can be overriden in derived classes
        public virtual void Steer(string direction)
        {
            Console.WriteLine("Steering " + direction);
        }
    }

    // This class cannot be extended because it is sealed
    public sealed class ElectricCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Electric car accelerate");
        }

        public override void Brake()
        {
            Console.WriteLine("Electric car brake");
        }
    }

    // This class needs to implement all the abstract methods from all the classes / interfaces it inherits
    public sealed class FlyingCar : Car, IFlyingThing // non interface classes must come before interfaces
    {
        // private internal enumerator; not accessible outside of this class
        enum FlyingCarMode
        {
            Fly,
            Drive
        };

        FlyingCarMode m_mode = FlyingCarMode.Drive;

        public void Fly()
        {
            m_mode = FlyingCarMode.Fly;
            Console.WriteLine("FyingCar flying");
        }

        public void Land()
        {
            Console.WriteLine("FyingCar landing");
            m_mode = FlyingCarMode.Drive;
        }

        public override void Accelerate()
        {
            Console.WriteLine("Flying car accelerate");
        }

        public override void Brake()
        {
            Console.WriteLine("Flying car brake");
        }

        // We are overriding the base class' method.
        public override void Steer(string direction)
        {
            if (m_mode == FlyingCarMode.Drive)
                Console.WriteLine("Steering in drive mode towards" + direction);
            else
                Console.WriteLine("Steering in fly mode towards" + direction);
        }
    }
}
