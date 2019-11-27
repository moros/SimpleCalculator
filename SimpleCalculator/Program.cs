using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please input string numbers to be added together.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            var calculator = new Calculator();
            var sum = calculator.Add(args[0]);

            Console.WriteLine($"Calculator.Add = {sum}.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
