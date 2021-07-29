using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    abstract class Marks
    {
        abstract public void getPercentage();
    }
    class StudentA : Marks
    {
        double Marks1, Marks2, Marks3;
        internal StudentA(double Marks1, double Marks2, double Marks3)
        {
            this.Marks1 = Marks1;
            this.Marks2 = Marks2;
            this.Marks3 = Marks3;
        }
        public override void getPercentage()
        {
            double Percentage = ((Marks1 + Marks2 + Marks3) / 300) * 100;
            Console.WriteLine("Percentage of Student A: {0} %", Percentage);
        }
    }
    class StudentB : Marks
    {
        double Marks1, Marks2, Marks3, Marks4;
        internal StudentB(double Marks1, double Marks2, double Marks3, double Marks4)
        {
            this.Marks1 = Marks1;
            this.Marks2 = Marks2;
            this.Marks3 = Marks3;
            this.Marks4 = Marks4;
        }
        public override void getPercentage()
        {
            double Percentage = ((Marks1 + Marks2 + Marks3 + Marks4) / 400) * 100;
            Console.WriteLine("Percentage of Student A: {0} %", Percentage);
        }
    }
    class Abstract_StudentPercentage
    {
        static void Main()
        {
            Marks marks = new StudentA(77.5, 80, 85);
            Marks marks1 = new StudentB(77.5, 60, 85, 50);
            marks.getPercentage();
            Console.WriteLine("-------------------------------");
            marks1.getPercentage();
        }
    }
}
