using System;

namespace TechTest_Ormuco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Line l1, l2;
            Console.WriteLine("Please enter number x1 for line1: ");
            l1.v1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter number x2 for line1: ");
            l1.v2 = Convert.ToDouble(Console.ReadLine());
            l1.ValueCheck();
            Console.WriteLine("Please enter x1 for line2: ");
            l2.v1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter x2 for line2: ");
            l2.v2 = Convert.ToDouble(Console.ReadLine());
            l2.ValueCheck();
            if (IsCross(l1, l2))
                Console.WriteLine("Cross");
            else
                Console.WriteLine("No Cross");
            Console.WriteLine("Press any key to end...");
            Console.ReadLine();

        }

        static bool IsCross(Line l1, Line l2)
        {
            return ((l1.v1 - l2.v2) * (l1.v2 - l2.v1)) <= 0 ? true : false;
        }

        struct Line
        {
            public double v1;
            public double v2;
            public void ValueCheck()
            {
                if (v1 > v2) { double tmp = v1; v1 = v2; v2 = tmp; };
            }
        }

    }
}
