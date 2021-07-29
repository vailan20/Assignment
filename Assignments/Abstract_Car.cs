using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    abstract class Abs_Car
    {
        protected int RegNo { get; set; }
        internal void OpenTank()
        {
            Console.WriteLine("This is open tank method");
        }
        abstract internal void Stearing(int direction, int angle);
        abstract public void Braking(int force);
    }
    class Tata : Abs_Car
    {
        internal override void Stearing(int direction, int angle)
        {
            Console.WriteLine("Direction: {0} || Angle: {1}", direction, angle);
        }
        public override void Braking(int force)
        {
            Console.WriteLine("Force: {0}", force);
        }
    }
    class Mahindra : Abs_Car
    {
        internal override void Stearing(int direction, int angle)
        {
            Console.WriteLine("Direction: {0} || Angle: {1}", direction, angle);
        }
        public override void Braking(int force)
        {
            Console.WriteLine("Force: {0}", force);
        }
    }
    class Abstract_Car
    {
        static void Main()
        {
            Abs_Car abscar = new Tata();
            abscar.OpenTank();
            abscar.Stearing(90, 90);
            abscar.Braking(100);
            Console.WriteLine("-------------------------------");
            Abs_Car abscar1 = new Mahindra();
            abscar1.OpenTank();
            abscar1.Stearing(900, 900);
            abscar1.Braking(1000);
        }
    }
}