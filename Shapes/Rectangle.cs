using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Rectangle
    {
        public double A { get; set;}
        public double B { get; set;}
        /// <summary>
        /// Фигура : Прямоугольник
        /// </summary>
        /// <param name="A">Сторона A прямоугольника</param>
        /// <param name="B">Сторона B прямоугольника</param>
        public Rectangle(double A, double B) 
        {
            this.A = A;
            this.B = B;
        }
        /// <summary>
        /// Фигура : Прямоугольник
        /// (Без параметров)
        /// </summary>
        public Rectangle() 
        {

        }
        /// <summary>
        /// Функция, которая выполняет вычисления площади прямоугольников
        /// </summary>
        /// <returns>Возвращает площадь прямоугольника</returns>
        public double Area() 
        {
            return Round(A*B,2);
        }
        /// <summary>
        /// Функция, которая выполняет вычисления периметра прямоугольников
        /// </summary>
        /// <returns>Возвращает периметр прямоугольника</returns>
        public double Perimeter() 
        {
            return Round((A+B)*2,2);
        }
    }
}
