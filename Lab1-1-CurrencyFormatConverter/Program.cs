using System;
using System.Globalization;

namespace Lab1_1_CurrencyFormatConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] vals = new float[] { 0, 0, 0 };
            GetValues(vals);
            Console.WriteLine("Your values are: {0}, {1}, and {2}", vals[0], vals[1], vals[2]);
            GetAverageMinMax(vals);
            CurrencyDisplay(vals);


            // End of Main
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();
        }
        private static void GetValues(float[] vals)
        {
            Console.WriteLine("Please enter 3 different dollar amounts:");
            for (int i = 0; i < vals.Length; i++)
            {
                bool notUnique = true;
                while (notUnique)
                {
                    vals[i] = GetFloat();
                    notUnique = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (vals[j] == vals[i])
                        {
                            Console.WriteLine("Please enter unique values. Repeat last entry:");
                            notUnique = true;
                        }
                    }
                }
            }
        }
        private static float GetFloat()
        {
            bool illegalInput = true;
            float myFloat = 0f;
            while (illegalInput)
            {
                try
                {
                    myFloat = float.Parse(Console.ReadLine());
                    if (myFloat < 0) throw new OverflowException();
                }
                catch (Exception e)
                {
                    if (e.GetType().ToString() == "System.OverflowException")
                    {
                        Console.WriteLine("Invalid entry, please enter a non-negative number that's not too big.");
                    }
                    else if (e.GetType().ToString() == "System.FormatException")
                    {
                        Console.WriteLine("Invalid entry, please use numbers");
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again.");
                    }
                    continue;
                }
                illegalInput = false;
            }
            return myFloat;
        }
        private static void GetAverageMinMax(float[] vals)
        {
            float average = vals[0];
            float total = vals[0];
            float min = vals[0];
            float max = vals[0];
            for(int i = 1; i < vals.Length; i++)
            {
                total += vals[i];
                min = Math.Min(min, vals[i]);
                max = Math.Max(max, vals[i]);
            }
            average = total / vals.Length;

            Console.WriteLine("For your values, the Total is {0}, the Average is {1}, the Smallest amount is {2}, and the Largest amount is {3}", total, average, min, max);
        }
        private static void CurrencyDisplay(float[] vals)
        {
            float total = 0;
            foreach (float val in vals)
            {
                total += val;
            }
            Console.WriteLine("The total value displayed as:");
            Console.WriteLine("United States Dollar: {0}", total.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            Console.WriteLine("Swedish Kroner: {0}", total.ToString("C", CultureInfo.GetCultureInfo("sv-SE")));
            Console.WriteLine("Japaneese Yen: {0}", total.ToString("C", CultureInfo.GetCultureInfo("ja-JP")));
            Console.WriteLine("Thai Baht: {0}", total.ToString("C", CultureInfo.GetCultureInfo("th-TH")));  // Alt-3647 - ?
        }
    }
}
