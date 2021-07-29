using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    abstract class Student
    {
        protected int StudentID { get; set; }
        protected string StudentName { get; set; }
        protected double Grade { get; set; }
        internal Student(int StudentID, string StudentName, double Grade)
        {
            this.StudentID = StudentID;
            this.StudentName = StudentName;
            this.Grade = Grade;
        }
        protected internal abstract bool IsPassed();
    }
    class Undergraduate : Student
    {
        internal Undergraduate(int StudentID, string StudentName, double Grade) : base(StudentID, StudentName, Grade) { }
        protected internal override bool IsPassed()
        {
            if (Grade > 70.0) return true;
            else return false;
        }
    }
    class Graduate : Student
    {
        internal Graduate(int StudentID, string StudentName, double Grade) : base(StudentID, StudentName, Grade) { }
        protected internal override bool IsPassed()
        {
            if (Grade > 80.0) return true;
            else return false;
        }
    }
    class Abstract_StudentPass
    {
        static void Main()
        {
            int StudentID;
            string StudentName;
            double Grade;
            string Stream;
            Console.WriteLine("Graduate or Undergraduate");
            Stream = Console.ReadLine();
            Console.WriteLine("Enter Student ID, Student Name and Grade");
            StudentID = Convert.ToInt32(Console.ReadLine());
            StudentName = Console.ReadLine();
            Grade = Convert.ToDouble(Console.ReadLine());
            if (Stream == "Graduate")
            {
                Student student1 = new Graduate(StudentID, StudentName, Grade);
                Console.WriteLine(student1.IsPassed());
            }
            else
            {
                Student student = new Undergraduate(StudentID, StudentName, Grade);
                Console.WriteLine(student.IsPassed());
            }
        }
    }
}
