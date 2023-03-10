using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Console;

namespace Figure_Calculator
{
    class ShapeMethods
    {
        public List<Shape> ShapeList = new List<Shape>(); 
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
                        
                        ShapeList.Add(circle);
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

                        ShapeList.Add(rectangle);

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

                        ShapeList.Add(square);

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
                            ShapeList.Add(triangle);

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
            if (ShapeList.Count != 0)
            {
                for (int i = 0; i < ShapeList.Count; i++)
                {

                    if (ShapeList[i] is Circle)
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Circle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Radius: {ShapeList[i].GetData("Radius")}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeList[i] is Rectangle)
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Rectangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {ShapeList[i].GetData("A")}\n   Side B : {ShapeList[i].GetData("B")}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeList[i] is Square)
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Square", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side : {ShapeList[i].GetData("Side")}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeList[i] is Triangle)
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Triangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {ShapeList[i].GetData("A")}\n   Side B : {ShapeList[i].GetData("B")}\n   Side C : {ShapeList[i].GetData("C")}", ConsoleColor.DarkYellow);
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
            ShapeList.Clear();
            BeautConsole.WriteLineColor("The figures have been successfully cleared",ConsoleColor.Green);
            ReadKey();
        }
        /// <summary>
        /// Находит общий периметр фигур
        /// </summary>
        /// <returns>Общий периметр фигур</returns>
        public double PerimetrAllShape()
        {
            double Perimeter = 0;
            for (int i = 0; i < ShapeList.Count; i++)
            {
                Perimeter += ShapeList[i].Perimeter();
            }
            return Perimeter;
        }
        /// <summary>
        /// Находит общую площадь фигур
        /// </summary>
        /// <returns>Общая площадь фигур</returns>
        public double AreaAllShape()
        {
            double Area = 0;
            for (int i = 0; i < ShapeList.Count; i++)
            {
                Area += ShapeList[i].Area();
            }
            return Area;
        }
        /// <summary>
        /// Записывает объект Shapes в a .json файл
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь файла</param>
        public void WriteToFile(string Path)
        {
            string json = JsonConvert.SerializeObject(ShapeList);

            File.Delete(Path);

            File.AppendAllText(Path, json);
        }
        /// <summary>
        /// Загружает объект Shapes из файла .json
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь до файла</param>
        public void UploadShapes(string Path)
        {
            using (StreamReader Reader = new StreamReader(Path))
            {
                string json = Reader.ReadToEnd();
                ShapeList = JsonConvert.DeserializeObject<List<Shape>>(json);
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
                if (ShapeList[figureNumb-1] is Circle)
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th circle: {ShapeList[figureNumb-1].Area()}", ConsoleColor.Yellow);
                }
                else if (ShapeList[figureNumb - 1] is Rectangle)
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th rectangle: {ShapeList[figureNumb-1].Area()}", ConsoleColor.DarkCyan);
                }
                else if (ShapeList[figureNumb - 1] is Square)
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th square: {ShapeList[figureNumb-1].Area()}", ConsoleColor.Blue);
                }
                else if (ShapeList[figureNumb - 1] is Triangle)
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th triangle: {ShapeList[figureNumb-1].Area()}", ConsoleColor.DarkGreen);
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
                if (ShapeList[figureNumb - 1] is Circle)
                {
                    Circle circle = (Circle)ShapeList[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb}th circle: {ShapeList[figureNumb].Perimeter()}", ConsoleColor.Yellow);
                }
                else if (ShapeList[figureNumb - 1] is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)ShapeList[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb}th rectangle: {rectangle.Perimeter()}", ConsoleColor.DarkCyan);
                }
                else if (ShapeList[figureNumb - 1] is Square)
                {
                    Square square = (Square)ShapeList[figureNumb - 1];
                    BeautConsole.WriteLineColor($"The perimetr of the {figureNumb} th square: {square.Perimeter()}", ConsoleColor.Blue);
                }
                else if (ShapeList[figureNumb - 1] is Triangle)
                {
                    Triangle triangle = (Triangle)ShapeList[figureNumb - 1];
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
