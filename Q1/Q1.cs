using System;

namespace Q1
{
    public class Q1
    {
        static void Main(string[] args)
        {
            Line l1 = new(0, 0), l2 = new(0, 0);
            Console.WriteLine("Please enter number x1 for line1: ");
            try
            {
                l1.v1 = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine("Please enter number x2 for line1: ");
            try
            {
                l1.v2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("please provide a valid input.");
            }
            l1.ValueCheck();
            Console.WriteLine("Please enter x1 for line2: ");
            try
            {
                l2.v1 = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("please provide a valid input.");
            }
            Console.WriteLine("Please enter x2 for line2: ");
            try
            {
                l2.v2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("please provide a valid input.");
            }
            l2.ValueCheck();
            if (IsCross(l1, l2))
                Console.WriteLine("Cross");
            else
                Console.WriteLine("No Cross");
            Console.WriteLine("Press any key to end...");
            Console.ReadLine();

        }

        /// <summary>
        /// Check if two range cross each other or not, include point. 
        /// </summary>
        /// <param name="l1">A X range</param>
        /// <param name="l2">A X range</param>
        /// <returns>Return true if there is a cross, otherwise, false. </returns>
        public static bool IsCross(Line l1, Line l2)
        {
            // we project two ranges to xy graph, either one can be y. 
            // Then, we get the box area formed by two ranges.
            // After that, the question then transfer into finding the cross between line y=x and the box area.
            // Which means finding out if the cross line in the box, which with negative k in y=kx, and is crossing with y=x, exist or not. 
            // Since we made sure that, in each of those ranges, v1 is always <= to v2.
            // Then, the box cross line with negative k can be calculated with two point, (l1.v1, l2.v2), (l1.v2, l2.v1).
            // Since we don't care about the crossing line but the cross itself, we put l1.v1 and l2.v2 inside y=x and compare them with the corresponding y value they already got. 
            // If the box is crossing with y=x, then the two result should share different signal, either both + or both -, which means one point is upper y=x, another point is below y=x;
            // To find out the final result we samply multiply them and compare with 0. 
            // The equal to 0 is here for conditions that the point is right on y=x which means the two ranges only have one point overlap each other. 
            // I take this situation as success cross. 
            return ((l1.v1 - l2.v2) * (l1.v2 - l2.v1)) <= 0 ? true : false;
        }

        public struct Line
        {
            public double v1;
            public double v2;

            public Line(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            // Make sure v1 is always <= to v2.
            public void ValueCheck()
            {
                if (v1 > v2) { double tmp = v1; v1 = v2; v2 = tmp; };
            }
        }

    }
}
