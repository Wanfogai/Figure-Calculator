using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Rectangle:Shape
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
        override public double Area() 
        {
            return Round(A*B,2);
        }
        /// <summary>
        /// Функция, которая выполняет вычисления периметра прямоугольников
        /// </summary>
        /// <returns>Возвращает периметр прямоугольника</returns>
        override public double Perimeter() 
        {
            return Round((A+B)*2,2);
        }

        public override double GetData(string DataName)
        {
            if (DataName.ToLower() == "a") return A;
            else return B;
        }
    }
}
