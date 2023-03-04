using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;

namespace Figure_Calculator
{
    class Shape
    {
        public BeautСonsole BeautConsole = new BeautСonsole();
        public Circle[] Circles = new Circle[] { };
        public Rectangle[] Rectangles = new Rectangle[] { };
        public Square[] Squares = new Square[] { };
        public Triangle[] Triangles = new Triangle[] { };
        public Dictionary<string, int> ShapeDic = new Dictionary<string, int> { };
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
                        Circle[] circle = new Circle[Circles.Length+1];
                        Circles.CopyTo(circle, 0);

                        BeautConsole.WriteColor("Enter the radius of the circle : ",ConsoleColor.DarkGray);
                        circle[circle.Length - 1] = new Circle
                        {
                            Radius = Convert.ToDouble(ReadLine())
                        };
                        ShapeDic.Add($"Circle{ShapeDic.Count}", circle.Length - 1);

                        Circles = circle;

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
                        Rectangle[] rectangle = new Rectangle[Rectangles.Length+1];
                        Rectangles.CopyTo(rectangle,0);

                        rectangle[rectangle.Length - 1] = new Rectangle();

                        BeautConsole.WriteColor("Enter side A : ",ConsoleColor.DarkGray);
                        rectangle[rectangle.Length-1].A = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side B : ",ConsoleColor.DarkGray);
                        rectangle[rectangle.Length-1].B = Convert.ToDouble(ReadLine());

                        ShapeDic.Add($"Rectangle{ShapeDic.Count}", rectangle.Length - 1);

                        Rectangles = rectangle;

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
                        Square[] square = new Square[Squares.Length+1];
                        Squares.CopyTo(square,0);

                        

                        BeautConsole.WriteColor("Enter the side of the square : ", ConsoleColor.DarkGray);
                        square[square.Length - 1] = new Square(Convert.ToDouble(ReadLine()));

                        ShapeDic.Add($"Square{ShapeDic.Count}", square.Length - 1);

                        Squares = square;
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
                        
                        Triangle[] triangle = new Triangle[Triangles.Length+1];
                        Triangles.CopyTo(triangle,0);

                        triangle[triangle.Length - 1] = new Triangle();

                        BeautConsole.WriteColor("Enter side A : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length-1].A = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side B : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length - 1].B = Convert.ToDouble(ReadLine());
                        BeautConsole.WriteColor("Enter side C : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length - 1].C = Convert.ToDouble(ReadLine());

                        if (triangle[triangle.Length - 1].IsValidate())
                        {
                            ShapeDic.Add($"Triangle{ShapeDic.Count}", triangle.Length - 1);

                            Triangles = triangle;

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
            if (ShapeDic.Count != 0)
            {
                for (int i = 0; i < ShapeDic.Count; i++)
                {
                    if (ShapeDic.ContainsKey($"Circle{i}"))
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Circle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Radius : {Circles[ShapeDic[$"Circle{i}"]].Radius}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Rectangle{i}"))
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Rectangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {Rectangles[ShapeDic[$"Rectangle{i}"]].A}\n   Side B : {Rectangles[ShapeDic[$"Rectangle{i}"]].B}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Square{i}"))
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Square", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side : {Squares[ShapeDic[$"Square{i}"]].Side}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Triangle{i}"))
                    {
                        BeautConsole.WriteLineColor($"{i + 1})Triangle", ConsoleColor.Yellow);
                        BeautConsole.WriteLineColor($"   Side A : {Triangles[ShapeDic[$"Triangle{i}"]].A}\n   Side B : {Triangles[ShapeDic[$"Triangle{i}"]].B}\n   Side C : {Triangles[ShapeDic[$"Triangle{i}"]].C}", ConsoleColor.DarkYellow);
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
            ShapeDic.Clear();
            Circles = new Circle[] { };
            Rectangles = new Rectangle[] { };
            Squares = new Square[] { };
            Triangles = new Triangle[] { };
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
            foreach (var item in Circles)
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in Rectangles)
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in Squares)
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in Triangles)
            {
                Perimetr += item.Perimeter();
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
            foreach (var item in Circles)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            foreach (var item in Rectangles)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            foreach (var item in Squares)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            foreach (var item in Triangles)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            return Area;
        }
        /// <summary>
        /// Записывает объект Shapes в a .json файл
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь файла</param>
        public void WriteToFile(Shape Shapes, string Path)
        {
            string json = JsonConvert.SerializeObject(Shapes);

            File.Delete(Path);

            File.AppendAllText(Path, json);
        }
        /// <summary>
        /// Загружает объект Shapes из файла .json
        /// </summary>
        /// <param name="Shapes">Фигуры</param>
        /// <param name="Path">Путь до файла</param>
        public void UploadShapes(ref Shape Shapes, string Path)
        {
            using (StreamReader Reader = new StreamReader(Path))
            {
                string json = Reader.ReadToEnd();
                json.ToArray();
                Shapes = JsonConvert.DeserializeObject<Shape>(json);
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
                if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Circle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th circle: {Circles[ShapeDic[$"Circle{figureNumb - 1}"]].Area()}", ConsoleColor.Yellow);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Rectangle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb}th rectangle: {Rectangles[ShapeDic[$"Rectangle{figureNumb - 1}"]].Area()}", ConsoleColor.DarkCyan);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Square{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th square:  {Squares[ShapeDic[$"Square{figureNumb - 1}"]].Area()}", ConsoleColor.Blue);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Triangle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The area of the {figureNumb} th triangle:  {Triangles[ShapeDic[$"Triangle{figureNumb - 1}"]].Area()}", ConsoleColor.DarkGreen);
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
                if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Circle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The perimeter of the {figureNumb}th circle: {Circles[ShapeDic[$"Circle{figureNumb - 1}"]].Perimeter()}", ConsoleColor.Yellow);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Rectangle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The perimeter of the {figureNumb}th rectangle: {Rectangles[ShapeDic[$"Rectangle{figureNumb - 1}"]].Perimeter()}", ConsoleColor.DarkCyan);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Square{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The perimeter of the {figureNumb}th square: {Squares[ShapeDic[$"Square{figureNumb - 1}"]].Perimeter()}", ConsoleColor.Blue);
                }
                else if (ShapeDic.Keys.ElementAt(figureNumb - 1) == $"Triangle{figureNumb - 1}")
                {
                    BeautConsole.WriteLineColor($"The perimeter of the {figureNumb}th triangle: {Triangles[ShapeDic[$"Triangle{figureNumb - 1}"]].Perimeter()}", ConsoleColor.DarkGreen);
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
