using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    class Vehicle
    {
        protected int RegnNumber { get; set; }
        protected double Speed { get; set; }
        protected string Color { get; set; }
        protected string OwnerName { get; set; }
        protected Vehicle(int RegnNumber, double Speed, string Color, string OwnerName)
        {
            this.RegnNumber = RegnNumber;
            this.Speed = Speed;
            this.Color = Color;
            this.OwnerName = OwnerName;
        }
        public virtual void ShowData()
        {
            Console.WriteLine("This is a vehicle class.");
        }
    }
    class Bus : Vehicle
    {
        private int RouteNumber { get; set; }
        internal Bus(int RegnNumber, double Speed, string Color, string OwnerName, int RouteNumber) : base(RegnNumber, Speed, Color, OwnerName)
        {
            this.RouteNumber = RouteNumber;
        }
        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Registration Number: {0}", base.RegnNumber);
            Console.WriteLine("Speed: {0} || Color: {1} || Owner Name: {2}", base.Speed, base.Color, base.OwnerName);
            Console.WriteLine("Route Number: {0}", RouteNumber);
        }
    }
    class Car : Vehicle
    {
        private string ManufactureName { get; set; }
        internal Car(int RegnNumber, double Speed, string Color, string OwnerName, string ManufactureName) : base(RegnNumber, Speed, Color, OwnerName)
        {
            this.ManufactureName = ManufactureName;
        }
        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Registration Number: {0}", base.RegnNumber);
            Console.WriteLine("Speed: {0} || Color: {1} || Owner Name: {2}", base.Speed, base.Color, base.OwnerName);
            Console.WriteLine("Manufacture Name: {0}", ManufactureName);
        }
    }
    class Vehicle_Inheritance
    {
        static void Main()
        {
            Bus bus = new Bus(12234533, 100.8, "Red", "Yashvi", 23);
            bus.ShowData();
            Console.WriteLine("----------------------------------------");
            Car car = new Car(12234533, 100.8, "Red", "Yashvi", "XYZ");
            car.ShowData();
        }
    }
}
