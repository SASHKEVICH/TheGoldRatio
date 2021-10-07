using System;

namespace TheGoldRatio
{
    public class GoldRatio
    {
        private const double _FI = 1.618;
        protected int _counterIteration;
        protected double _leftBound;
        protected double _rightBound;
        protected double _eps;
        
        public GoldRatio() {}
        public GoldRatio(double leftBound, double rightBound, double eps)
        {
            this._leftBound = leftBound;
            this._rightBound = rightBound;
            this._eps = eps;
        }

        /// <summary>
        /// Метод возвращает точку минимума заданной функции.
        /// </summary>
        /// <param name="func">Задаваемая функция.</param>
        /// <returns></returns>
        public virtual double FindMin(Func<double, double> func)
        {
            while(Math.Abs(_rightBound - _leftBound) > _eps)
            {
                double x1 = _rightBound - (_rightBound - _leftBound) / _FI;
                double x2 = _leftBound + (_rightBound - _leftBound) / _FI;

                double y1 = func(x1);
                double y2 = func(x2);

                if (y1 >= y2)
                {
                    _leftBound = x1;
                }
                else
                {
                    _rightBound = x2;
                }
            }

            return (_leftBound + _rightBound) / 2;
        }
    }
}