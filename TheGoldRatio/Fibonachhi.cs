using System;

namespace TheGoldRatio
{
    public class Fibonachhi : GoldRatio
    {
        private int FibonachhiNumber;
        
        /// <summary>
        /// Метод вычисляет число Фибоначчи по заданному номеру.
        /// </summary>
        /// <param name="numberOfSeries">Номер числа Фибоначчи</param>
        /// <returns></returns>
        private int FibonachhiSeries(int numberOfSeries)
        {
            int f0 = 0;
            int f1 = 1;
            int fn = 0;

            if (numberOfSeries < 1)
            {
                return 0;
            }

            for (int i = 0; i < numberOfSeries; i++)
            {
                fn = f0 + f1;
                f0 = f1;
                f1 = fn;
            }

            return fn;
        }
        
        /// <summary>
        /// Метод ищет ближайший номер числа Фибоначчи, которое бы удовлетворяло неравенству.
        /// </summary>
        /// <returns></returns>
        public int FindNumberOfSeries()
        {
            int numberOfSeries = 0;
            int x = Convert.ToInt32((_rightBound - _leftBound) / _eps);

            while (FibonachhiSeries(numberOfSeries) < x)
            {
                numberOfSeries++;
            }

            return numberOfSeries;
        }
        
        public override double FindMin(Func<double, double> func)
        {
            FibonachhiNumber = FindNumberOfSeries();
            int neededNumberOfSeries = FibonachhiNumber;
            int counter = 0;
            double step = (_rightBound - _leftBound) / FibonachhiSeries(neededNumberOfSeries);

            double x1 = _leftBound + step * FibonachhiSeries(neededNumberOfSeries + 2);
            double x2 = _rightBound - step * FibonachhiSeries(neededNumberOfSeries + 2);

            double y1 = func(x1);
            double y2 = func(x2);

            while (counter < neededNumberOfSeries)
            {
                counter++;

                if (y1 < y2)
                {
                    _rightBound = x2;
                    x2 = x1;
                    y2 = y1;
                    x1 = _leftBound + step * FibonachhiSeries(neededNumberOfSeries - counter + 2);
                    y1 = func(x1);
                }
                else
                {
                    _leftBound = x1;
                    x1 = x2;
                    y1 = y2;
                    x2 = _rightBound - step * FibonachhiSeries(neededNumberOfSeries - counter + 2);
                    y2 = func(x2);
                }
            }

            return (_leftBound + _rightBound) / 2.0;
        }

        public Fibonachhi(double LeftBound, double RightBound, double eps)
        {
            
        }
    }
}