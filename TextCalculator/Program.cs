using System;

namespace TextCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            while (true)
            {
                Console.Write("Введите выражение: " );
                var input = Console.ReadLine();

                var result = calculator.CalculateExpression($"({input})");
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}
