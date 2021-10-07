using System;
using System.Globalization;

namespace TheGoldRatio
{
    class Program
    {
        private static double _leftBound;
        private static double _rightBound;
        private static double _eps;
        
        static void Main(string[] args)
        {
            setBounds();
            GoldRatio GRSolver = new GoldRatio(_leftBound, _rightBound, _eps);

            double GRminimum = GRSolver.FindMin(Func1);
            Console.WriteLine($"Минимум искомой функции = {GRminimum}.");
            Console.WriteLine($"Значение минимума искомой функции = {Func1(GRminimum)}.");

        }
        
        private static double Func1(double x)
        {
            return Math.Pow(x, 2) - 9;
        }
        
        private static double Func2(double x)
        {
            return Math.Pow(x - 3, 2) + 4;
        }

        private static void setBounds()
        {
            Console.Write("Введите левую границу: ");
            _leftBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите правую границу: ");
            _rightBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите погрешность: ");
            _eps = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

    }
}
