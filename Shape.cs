namespace Figure_Calculator
{
    abstract class Shape
    {
        /// <summary>
        /// Метод созданный для получения параметра фигуры
        /// </summary>
        /// <param name="ParamName">Имя параметра, который надо получить</param>
        /// <returns></returns>
        abstract public double GetParam(string ParamName);
        abstract public double Area();
        abstract public double Perimeter();
    }
}
