using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thermostat_
{
    internal class Thermostat
    {
        Task<double> t = new Task<double>(Run);
        static double currentTemp;
        public static double newTemp;
        public static double TEMP;
        private static double Run()
        {
            double input;
            while ((input = Input()) != 0)
            {
                currentTemp = newTemp;
                newTemp = input;
            }
            Console.WriteLine($"You entered: {input} in thread. This will stop the program");
            Environment.Exit(1);
            return 0;
        }
        public Thermostat(double CurrentTemp, double NewTemp)
        {
            currentTemp = CurrentTemp;
            newTemp = NewTemp;
            double input = NewTemp;
            double c, n;
            t.Start();
            while (true)
            {
                c = StartThermostat(currentTemp, newTemp);
                currentTemp = c;
                n = StopThermostat(currentTemp, newTemp);
                currentTemp = n;
            }
        }
        public double StopThermostat(double currentTemp, double newTemp)
        {
            Console.WriteLine("--Stop");
            return cooler(currentTemp, newTemp);   
        }
        public double StartThermostat(double currentTemp, double newTemp)
        {
            Console.WriteLine("--Start");
            return heater(currentTemp, newTemp);
        }
        private static double cooler(double currentTemp, double newTemp)
        {
            while (currentTemp > newTemp - 0.25)
            {
                ViewTemp(currentTemp);
                currentTemp -= 0.5;
                Thread.Sleep(1500);
            }
            return currentTemp;
        }
        private static double heater(double currentTemp, double newTemp)
        {
            while (currentTemp <= newTemp + 0.2)
            {
                ViewTemp(currentTemp);
                currentTemp += 0.3;
                Thread.Sleep(1500);
            }
            return currentTemp - 0.3;
        }
        private static void ViewTemp(double currentTemp)
        {
            string h = DateTime.Now.Hour.ToString("00").PadLeft(2);
            string m = DateTime.Now.Minute.ToString("00").PadLeft(2);
            string s = DateTime.Now.Second.ToString("00").PadLeft(2);
            string c = currentTemp.ToString("0.00").ToString().PadLeft(5);
            Console.WriteLine("Time " + h + ":" + m + ":" + s + " | " + c);
        }
        public static double Input()
        {
            double inputTemp = 0;
            bool b = false;
            do
            {
                //Entring a value can fail 
                b = double.TryParse(Console.ReadLine(), out inputTemp);
                if (b == false) Console.WriteLine("Something went wrong! Please reenter the temperature.");
            } while (b == false);
            return inputTemp;
        }
    }
}