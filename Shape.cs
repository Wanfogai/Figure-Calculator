using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    abstract class Shape
    {
        /// <summary>
        /// Метод созданный для получения параметра фигуры
        /// </summary>
        /// <param name="DataName">Имя параметра, который надо получить</param>
        /// <returns></returns>
        abstract public double GetData(string DataName);
        abstract public double Area();
        abstract public double Perimeter();
    }
}
