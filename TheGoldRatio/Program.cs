using System;
using System.Globalization;

namespace TheGoldRatio
{
    class Program
    {
        static void Main(string[] args)
        {
            double leftBound;
            double rightBound;
            double eps;
            
            Console.Write("Введите левую границу: ");
            leftBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите правую границу: ");
            rightBound = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Введите погрешность: ");
            eps = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double minResult = GoldRatio.FindMin(leftBound, rightBound, eps);
            double maxResult = GoldRatio.FindMax(leftBound, rightBound, eps);
            
            Console.WriteLine($"Наименьшее значение функции = {minResult}");
            Console.WriteLine($"Наибольшее значение функции = {maxResult}");
        }
    }

    class GoldRatio
    {
        private const double fi = 1.6180;
        
        static double MainFunction(double x)
        {
            return Math.Pow(x, 2) - 9;
        }
        
        public static double FindMin(double leftBound, double rightBound, double eps)
        {
            while(true)
            {
                double x1 = rightBound - (rightBound - leftBound) / fi;
                double x2 = leftBound + (rightBound - leftBound) / fi;

                double y1 = MainFunction(x1);
                double y2 = MainFunction(x2);

                if (y1 >= y2)
                {
                    leftBound = x1;
                }
                else
                {
                    rightBound = x2;
                }

                if (Math.Abs(rightBound - leftBound) < eps)
                {
                    break;
                }
            }

            return MainFunction((leftBound + rightBound) / 2);
        }
        public static double FindMax(double leftBound, double rightBound, double eps)
        {
            while(true)
            {
                double x1 = rightBound - (rightBound - leftBound) / fi;
                double x2 = leftBound + (rightBound - leftBound) / fi;

                double y1 = MainFunction(x1);
                double y2 = MainFunction(x2);

                if (y1 <= y2)
                {
                    leftBound = x1;
                }
                else
                {
                    rightBound = x2;
                }

                if (Math.Abs(rightBound - leftBound) < eps)
                {
                    break;
                }
            }

            return MainFunction((leftBound + rightBound) / 2);
        }
    }
}
