using System;

namespace TheGoldRatio
{
    public class GoldRatio
    {
        private const double fi = 1.618;
        protected int CounterIteration;
        protected double LeftBound;
        protected double RightBound;
        protected double eps;
        
        public GoldRatio() {}
        public GoldRatio(double leftBound, double rightBound, double eps)
        {
            LeftBound = leftBound;
            RightBound = rightBound;
            this.eps = eps;
        }

        /// <summary>
        /// Метод возвращает точку минимума заданной функции.
        /// </summary>
        /// <param name="func">Задаваемая функция.</param>
        /// <returns></returns>
        public virtual double FindMin(Func<double, double> func)
        {
            while(true)
            {
                CounterIteration++;
                double x1 = RightBound - (RightBound - LeftBound) / fi;
                double x2 = LeftBound + (RightBound - LeftBound) / fi;

                double y1 = func(x1);
                double y2 = func(x2);

                if (y1 >= y2)
                {
                    LeftBound = x1;
                }
                else
                {
                    RightBound = x2;
                }

                if (Math.Abs(RightBound - LeftBound) < eps)
                {
                    break;
                }
            }

            return (LeftBound + RightBound) / 2;
        }
        
        public double FindMax(Func<double, double> func)
        {
            while(true)
            {
                CounterIteration++;
                double x1 = RightBound - (RightBound - LeftBound) / fi;
                double x2 = LeftBound + (RightBound - LeftBound) / fi;

                double y1 = func(x1);
                double y2 = func(x2);

                if (y1 <= y2)
                {
                    LeftBound = x1;
                }
                else
                {
                    RightBound = x2;
                }

                if (Math.Abs(RightBound - LeftBound) < eps)
                {
                    break;
                }
            }

            return (LeftBound + RightBound) / 2;
        }
    }
}