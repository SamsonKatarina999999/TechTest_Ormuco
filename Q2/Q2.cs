using System;

namespace Q2
{
    public class Q2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter version number 1: ");
            string v1 = Console.ReadLine();
            Console.WriteLine("Please enter version number 2: ");
            string v2 = Console.ReadLine();
            try
            {
                if (VersionComparator(v1, v2))
                {
                    Console.WriteLine($"Version {v1} is smaller than version {v2}.");
                }
                else
                {
                    Console.WriteLine($"Version {v1} is bigger than version {v2}.");
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Invalid version format. ");
            }
            Console.WriteLine("Press any key to end...");
            Console.ReadLine();

        }

        /// <summary>
        /// Compare two version, see if version 1 is smaller than version 2. Same begin version number but longer will be consider newer. 
        /// </summary>
        /// <param name="v1">version 1 </param>
        /// <param name="v2">version 2</param>
        /// <returns>Return true if version 1 is smaller or equal than version 2, otherwise, false. </returns>
        public static bool VersionComparator(string v1, string v2)
        {
            var strArray1 = v1.Split(".");
            var strArray2 = v2.Split(".");
            for (int i = 0; (i < strArray1.Length) && (i <= strArray2.Length); i++)
            {
                if (i == strArray2.Length && (Convert.ToInt32(strArray1[i-1]) == Convert.ToInt32(strArray2[i-1]))) 
                {
                    return false;
                }
                if (Convert.ToInt32(strArray1[i]) > Convert.ToInt32(strArray2[i]))
                    return false;
            }
            return true;
        }
    }
}
