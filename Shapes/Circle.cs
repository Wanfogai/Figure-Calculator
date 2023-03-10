using static System.Math;

namespace Figure_Calculator
{
    class Circle : Shape
    {
        public double Radius { get; set; }
        /// <summary>
        /// Фигура : Круг
        /// </summary>
        /// <param name="Radius">Радиус круга</param>
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }
        /// <summary>
        /// Фигура : Кург
        /// (Без параметров)
        /// </summary>
        public Circle()
        {

        }
        /// <summary>
        /// Функция, которая выполняет вычисления площади окружностей
        /// </summary>
        /// <returns>Возвращает площадь круга</returns>
        override public double Area()
        {
            return Round(PI * Pow(Radius, 2), 2);
        }
        /// <summary>
        /// Функция, которая выполняет вычисления периметра окружностей
        /// </summary>
        /// <returns>Возвращает периметр круга</returns>
        override public double Perimeter()
        {
            return Round(2 * PI * Radius, 2);
        }
        public override double GetParam(string DataName = "Radius")
        {
            return Radius;
        }
    }
}
