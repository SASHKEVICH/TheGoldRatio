using System;
using System.Globalization;

namespace TheGoldRatio
{
    class Program
    {
        private static double LeftBound;
        private static double RightBound;
        private static double eps;
        
        static void Main(string[] args)
        {
            setBounds();
            GoldRatio GRSolver = new GoldRatio(LeftBound, RightBound, eps);

            double GRminimum = GRSolver.FindMin(Func1);
            Console.WriteLine($"Минимум искомой функции = {GRminimum}.");
            Console.WriteLine($"Значение минимума искомой функции = {Func1(GRminimum)}.");
            
            setBounds();
            Fibonachhi FBSolver = new Fibonachhi(LeftBound, RightBound, eps);
            
            double FBminimum = FBSolver.FindMin(Func2);
            Console.WriteLine($"Минимум искомой функции = {FBminimum}.");
            Console.WriteLine($"Значение минимума искомой функции = {Func2(FBminimum)}.");
            
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
            LeftBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите правую границу: ");
            RightBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите погрешность: ");
            eps = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

    }
}
