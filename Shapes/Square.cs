using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Square
    {
        public double Side { get; set; }
        /// <summary>
        /// Фигура : Квадрат
        /// </summary>
        /// <param name="Side">SСторона квадрата</param>
        public Square(double Side)
        {
            this.Side = Side;
        }
        /// <summary>
        /// Фигура : Квадрат
        /// (Без параметров)
        /// </summary>
        public Square() 
        {

        }
        /// <summary>
        /// Функция, которая выполняет вычисления площади квадратов
        /// </summary>
        /// <returns>Возвращает площадь квадрата</returns>
        public double Area() 
        {
            return Round(Pow(Side,2),2);
        }
        /// <summary>
        /// Функция, которая выполняет вычисления периметра квадратов
        /// </summary>
        /// <returns>Возвращает периметр квадрата</returns>
        public double Perimeter() 
        {
            return Round(Side * 4, 2); 
        }


    }
}
