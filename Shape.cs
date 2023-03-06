using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;

namespace Figure_Calculator
{
    class Shape
    {
        public List<object> Shapes = new List<object>(); 
        public BeautСonsole BeautConsole = new BeautСonsole();
        /// <summary>
        /// Функция добавления новой фигуры
        /// </summary>
        public void AddNewShape()
        {
            string comand;
            Clear();
            BeautConsole.WriteLineColor("Add a shape:",ConsoleColor.Yellow);
            BeautConsole.WriteLineColor("1)Circle",ConsoleColor.Cyan);
            BeautConsole.WriteLineColor("2)Rectangle", ConsoleColor.Cyan);
            BeautConsole.WriteLineColor("3)Square", ConsoleColor.Cyan);
            BeautConsole.WriteLineColor("4)Triangle", ConsoleColor.Cyan);
            WriteLine();
            BeautConsole.WriteColor("Write shape number : ",ConsoleColor.DarkGray);
            comand = ReadLine();
            switch (comand)
            {
                case "1":
                    Clear();
                    try
                    {
                        Circle circle = new Circle();

                        BeautConsole.WriteColor("Enter the radius of the circle : ", ConsoleColor.DarkGray);
                        circle.Radius = Convert.ToDouble(ReadLine());

                        Shapes.Add(circle);

                        BeautConsole.WriteLineColor("The shape has been added successfully", ConsoleColor.Green);
                        break;

                       }
                    catch (Exception)
                    {
                        BeautConsole.WriteLineColor("Error!!!", ConsoleColor.Red);
                        break;
                    }
                case "2":
                    Clear();
                    try
                    {
                        Rectangle rectangle = new Rectangle();

                        BeautConsole.WriteColor("Enter side A : ",ConsoleColor.DarkGray);
                        rectangle.A = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side B : ",ConsoleColor.DarkGray);
                        rectangle.B = Convert.ToDouble(ReadLine());

                        Shapes.Add(rectangle);

                        BeautConsole.WriteColor("The shape has been added successfully", ConsoleColor.Green);
                    }
                    catch (Exception)
                    {
                        BeautConsole.WriteColor("Error!!!", ConsoleColor.Red);
                        break;
                    }
                    break;
                case "3":
                    Clear();
                    try
                    {
                        Square square = new Square();

                        BeautConsole.WriteColor("Enter the side of the square : ", ConsoleColor.DarkGray);
                        square.Side = Convert.ToDouble(ReadLine());

                        Shapes.Add(square);

                        BeautConsole.WriteLineColor("The shape has been added successfully",ConsoleColor.Green);
                    }
                    catch (Exception)
                    {
                        BeautConsole.WriteColor("Error!!!", ConsoleColor.Red);
                        break;
                    }
                    break;
                case "4":
                    Clear();
                    try
                    {
                        
                        Triangle triangle = new Triangle();

                        BeautConsole.WriteColor("Enter side A : ", ConsoleColor.DarkGray);
                        triangle.A = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side B : ", ConsoleColor.DarkGray);
                        triangle.B = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side C : ", ConsoleColor.DarkGray);
                        triangle.C = Convert.ToDouble(ReadLine());

                        if (triangle.IsValidate())
                        {
                            Shapes.Add(triangle);

                            BeautConsole.WriteColor("The shape has been added successfully", ConsoleColor.Green);
                            break;
                        }
                        else
                        {
                            BeautConsole.WriteLineColor("Such a triangle cannot exist",ConsoleColor.Red);
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        BeautConsole.WriteLineColor("Error!!!",ConsoleColor.Red);
                        break;
                    }
                default:
                    BeautConsole.WriteLineColor("Wrong shape", ConsoleColor.Red);
                    break;
            }
        }
        /// <summary>
        /// Функция для отображения полного списка фигур и их параметров
        /// </summary>
        public void OutputAllShapes() 
        {
            Clear();
            if (Shapes.Count != 0)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {
                    if (Shapes[i].ToString() == typeof(Circle).FullName)
                    {
                        Circle circle = (Circle)Shapes[i];
                        BeautConsole.WriteLineColor($"{i + 1})Circle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Radius : {circle.Radius}", ConsoleColor.DarkYellow);
                    }
                    else if (Shapes[i].ToString() == typeof(Rectangle).FullName)
                    {
                        Rectangle rectangle = (Rectangle)Shapes[i];
                        BeautConsole.WriteLineColor($"{i + 1})Rectangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {rectangle.A}\n   Side B : {rectangle.B}", ConsoleColor.DarkYellow);
                    }
                    else if (Shapes[i].ToString() == typeof(Square).FullName)
                    {
                        Square square = (Square)Shapes[i];
                        BeautConsole.WriteLineColor($"{i + 1})Square", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side : {square.Side}", ConsoleColor.DarkYellow);
                    }
                    else if (Shapes[i].ToString() == typeof(Triangle).FullName)
                    {
                        Triangle triangle = (Triangle)Shapes[i];
                        BeautConsole.WriteLineColor($"{i + 1})Triangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {triangle.A}\n   Side B : {triangle.B}\n   Side C : {triangle.C}", ConsoleColor.DarkYellow);
                    }
                    WriteLine();
                }
            }
            else 
            {
                BeautConsole.WriteLineColor("The list of figures is empty :(",ConsoleColor.Red);
            }
            
        }
        /// <summary>
        /// Функция очистки фигур
        /// </summary>
        public void ClearShapes() 
        {
            Shapes.Clear();
            BeautConsole.WriteLineColor("The figures have been successfully cleared",ConsoleColor.Green);
            ReadKey();
        }
        /// <summary>
        /// Находит общий периметр фигур
        /// </summary>
        /// <returns>Общий периметр фигур</returns>
        public double PerimetrAllShape()
        {
            double Perimetr = 0;
            for (int i = 0; i < Shapes.Count; i++)
            {
                if (Shapes[i].ToString() == typeof(Circle).FullName)
                {
                    Circle circle = (Circle)Shapes[i];
                    Perimetr += circle.Perimeter();
                }
                else if (Shapes[i].ToString() == typeof(Rectangle).FullName)
                {
                    Rectangle rectangle = (Rectangle)Shapes[i];
                    Perimetr += rectangle.Perimeter();
                }
                else if (Shapes[i].ToString() == typeof(Square).FullName)
                {
                    Square square = (Square)Shapes[i];
                    Perimetr += square.Perimeter();
                }
                else if (Shapes[i].ToString() == typeof(Triangle).FullName)
                {
                    Triangle triangle = (Triangle)Shapes[i];
                    Perimetr += triangle.Perimeter();
                }
            }
            return Perimetr;
        }
        /// <summary>
        /// Находит общую площадь фигур
        /// </summary>
        /// <returns>Общая площадь фигур</returns>
        public double AreaAllShape()
        {
            double Area = 0;
            for (int i = 0; i < Shapes.Count; i++)
            {
                if (Shapes[i].ToString() == typeof(Circle).FullName)
                {
                    Circle circle = (Circle)Shapes[i];
                    Area += circle.Area();
                }
                else if (Shapes[i].ToString() == typeof(Rectangle).FullName)
                {
                    Rectangle rectangle = (Rectangle)Shapes[i];
                    Area += rectangle.Area();
                }
                else if (Shapes[i].ToString() == typeof(Square).FullName)
                {
                    Square square = (Square)Shapes[i];
                    Area += square.Area();
                }
                else if (Shapes[i].ToString() == typeof(Triangle).FullName)
                {
                    Triangle triangle = (Triangle)Shapes[i];
                    Area += triangle.Area();
                }
            }
            return Area;
        }
        /// <summary>
        /// Записывает объект Shapes в a .json файл
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь файла</param>
        public void WriteToFile( string Path)
        {
            string json = JsonConvert.SerializeObject(Shapes[0]);

            File.Delete(Path);

            File.AppendAllText(Path, json);
        }
        /// <summary>
        /// Загружает объект Shapes из файла .json
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь до файла</param>
        public void UploadShapes( string Path)
        {
            using (StreamReader Reader = new StreamReader(Path))
            {
                string json = Reader.ReadToEnd();
                json.ToArray();
                Shapes = JsonConvert.DeserializeObject<List<object>>(json);
            }
        }
        /// <summary>
        /// Функция для вывода площади выбранной пользователем фигуры
        /// </summary>
        public void OutputAreaShape() 
        {
            OutputAllShapes();
            try
            {     
                BeautConsole.WriteColor("Enter the shape number : ", ConsoleColor.DarkGray);
                int figureNumb = Convert.ToInt32(ReadLine());
                if (Shapes[figureNumb-1].ToString() == typeof(Circle).FullName)
                {
                    Circle circle = (Circle)Shapes[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th circle: {circle.Area()}", ConsoleColor.Yellow);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Rectangle).FullName)
                {
                    Rectangle rectangle = (Rectangle)Shapes[figureNumb-1];
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th rectangle: {rectangle.Area()}", ConsoleColor.DarkCyan);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Square).FullName)
                {
                    Square square = (Square)Shapes[figureNumb-1];
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th square: {square.Area()}", ConsoleColor.Blue);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Triangle).FullName)
                {
                    Triangle triangle = (Triangle)Shapes[figureNumb-1];
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th triangle: {triangle.Area()}", ConsoleColor.DarkGreen);
                }
                ReadKey();
            }
            catch (Exception)
            {
                BeautConsole.WriteLineColor("Error!!!", ConsoleColor.Red);
                ReadKey();
            }
        }
        /// <summary>
        /// Функция для вывода периметра выбранной пользователем фигуры
        /// </summary>
        public void OutputPerimetrShape() 
        {
            OutputAllShapes();
            try
            {
                BeautConsole.WriteColor("Enter the shape number : ", ConsoleColor.DarkGray);
                int figureNumb = Convert.ToInt32(ReadLine());
                if (Shapes[figureNumb - 1].ToString() == typeof(Circle).FullName)
                {
                    Circle circle = (Circle)Shapes[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb}th circle: {circle.Perimeter()}", ConsoleColor.Yellow);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Rectangle).FullName)
                {
                    Rectangle rectangle = (Rectangle)Shapes[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb}th rectangle: {rectangle.Perimeter()}", ConsoleColor.DarkCyan);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Square).FullName)
                {
                    Square square = (Square)Shapes[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb} th square: {square.Perimeter()}", ConsoleColor.Blue);
                }
                else if (Shapes[figureNumb - 1].ToString() == typeof(Triangle).FullName)
                {
                    Triangle triangle = (Triangle)Shapes[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb} th triangle: {triangle.Perimeter()}", ConsoleColor.DarkGreen);
                }
                ReadKey();
            }
            catch (Exception)
            {
                BeautConsole.WriteLineColor("Error!!!", ConsoleColor.Red);
                ReadKey();
            }
        }
    }
}
