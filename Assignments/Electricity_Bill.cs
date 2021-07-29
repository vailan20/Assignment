using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    class Electricity_Bill
    {
        double TotalBill { get; set; }
        int Units { get; set; }

        Electricity_Bill(int Units)
        {
            this.Units = Units;
        }
        static double CalculateBill(Electricity_Bill ebill)
        {
            double TotalBill;
            if (ebill.Units <= 100) { TotalBill = ebill.Units * 1.20; return TotalBill; }
            else if (ebill.Units > 100 && ebill.Units <= 300) { TotalBill = (100 * 1.20) + ((ebill.Units - 100) * 2.00); return TotalBill; }
            else if (ebill.Units > 300) { TotalBill = (100 * 1.20) + ((ebill.Units - 200) * 2.00) + ((ebill.Units - 300) * 3.00); return TotalBill; }
            else return 0;
        }
        static void Main()
        {
            int Units;
            Console.WriteLine("Enter Units");
            Units = Convert.ToInt32(Console.ReadLine());

            Electricity_Bill ebill = new Electricity_Bill(Units);
            Console.WriteLine("Electricity Bill: {0}", Electricity_Bill.CalculateBill(ebill));
        }
    }
}
