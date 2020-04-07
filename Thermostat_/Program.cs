using System;

namespace Thermostat_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Time hh:mm:ss | Temp.");
            double currentTemp = 20;
            string h = DateTime.Now.Hour.ToString("00").PadLeft(2);
            string m = DateTime.Now.Minute.ToString("00").PadLeft(2);
            string s = DateTime.Now.Second.ToString("00").PadLeft(2);
            Console.WriteLine($"Time {h}:{m}:{s} | {currentTemp.ToString("0.00").ToString().PadLeft(5)}");
            Console.WriteLine();
            double newTemp;
            newTemp = Input();
            new Thermostat(currentTemp, newTemp);
            Console.WriteLine();
        }
        public static double Input()
        {
            double inputTemp = 0;
            bool b = false;
            do
            {
                Console.Write("Enter temperature: ");
                //Entring a value can fail 
                b = double.TryParse(Console.ReadLine(), out inputTemp);
                if (b == false) Console.WriteLine("Something went wrong! Please reenter the temperature.");
            } while (b == false);
            if (inputTemp == 0)
            {
                Console.WriteLine($"You entered: {inputTemp}. This will stop the program");
                Environment.Exit(0);
            }
            return inputTemp;
        }
    }
}
