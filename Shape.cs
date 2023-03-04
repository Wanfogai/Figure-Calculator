using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Figure_Calculator
{
    class Shape
    {
        protected BeautСonsole _functions = new BeautСonsole();

        public Circle[] Circles;
        public Rectangle[] Rectangles;
        public Square[] Squares;
        public Triangle[] Triangles;
        public Dictionary<string, int> ShapeDic;
        /// <summary>
        /// Конструктор для фигур и список фигур
        /// </summary>
        public Shape() 
        {
            Circles = new Circle[] { };
            Rectangles = new Rectangle[] { };
            Squares = new Square[] { }; 
            Triangles = new Triangle[] { };
            ShapeDic = new Dictionary<string, int> { };
        }
        /// <summary>
        /// Функция добавления новой фигуры
        /// </summary>
        public void AddNewShape()
        {
            string comand;
            Clear();
            _functions.WriteLineColor("Add a shape:",ConsoleColor.Yellow);
            _functions.WriteLineColor("1)Circle",ConsoleColor.Cyan);
            _functions.WriteLineColor("2)Rectangle", ConsoleColor.Cyan);
            _functions.WriteLineColor("3)Square", ConsoleColor.Cyan);
            _functions.WriteLineColor("4)Triangle", ConsoleColor.Cyan);
            WriteLine();
            _functions.WriteColor("Write shape number : ",ConsoleColor.DarkGray);
            comand = ReadLine();
            switch (comand)
            {
                case "1":
                    Clear();
                    try
                    {
                        Circle[] circle = new Circle[Circles.Length+1];
                        Circles.CopyTo(circle, 0);

                        _functions.WriteColor("Enter the radius of the circle : ",ConsoleColor.DarkGray);
                        circle[circle.Length - 1] = new Circle
                        {
                            Radius = Convert.ToDouble(ReadLine())
                        };
                        ShapeDic.Add($"Circle{ShapeDic.Count}", circle.Length - 1);

                        Circles = circle;

                        _functions.WriteLineColor("The shape has been added successfully", ConsoleColor.Green);
                        break;

                       }
                    catch (Exception)
                    {
                        _functions.WriteLineColor("Error!!!", ConsoleColor.Red);
                        break;
                    }
                case "2":
                    Clear();
                    try
                    {
                        Rectangle[] rectangle = new Rectangle[Rectangles.Length+1];
                        Rectangles.CopyTo(rectangle,0);

                        rectangle[rectangle.Length - 1] = new Rectangle();

                        _functions.WriteColor("Enter side A : ",ConsoleColor.DarkGray);
                        rectangle[rectangle.Length-1].A = Convert.ToDouble(ReadLine());
                        _functions.WriteColor("Enter side B : ",ConsoleColor.DarkGray);
                        rectangle[rectangle.Length-1].B = Convert.ToDouble(ReadLine());

                        ShapeDic.Add($"Rectangle{ShapeDic.Count}", rectangle.Length - 1);

                        Rectangles = rectangle;

                        _functions.WriteColor("The shape has been added successfully", ConsoleColor.Green);
                    }
                    catch (Exception)
                    {
                        _functions.WriteColor("Error!!!", ConsoleColor.Red);
                        break;
                    }
                    break;
                case "3":
                    Clear();
                    try
                    {
                        Square[] square = new Square[Squares.Length+1];
                        Squares.CopyTo(square,0);

                        

                        _functions.WriteColor("Enter the side of the square : ", ConsoleColor.DarkGray);
                        square[square.Length - 1] = new Square(Convert.ToDouble(ReadLine()));

                        ShapeDic.Add($"Square{ShapeDic.Count}", square.Length - 1);

                        Squares = square;
                        _functions.WriteLineColor("The shape has been added successfully",ConsoleColor.Green);
                    }
                    catch (Exception)
                    {
                        _functions.WriteColor("Error!!!", ConsoleColor.Red);
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

                        _functions.WriteColor("Enter side A : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length-1].A = Convert.ToDouble(ReadLine());
                        _functions.WriteColor("Enter side B : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length - 1].B = Convert.ToDouble(ReadLine());
                        _functions.WriteColor("Enter side C : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length - 1].C = Convert.ToDouble(ReadLine());

                        if (triangle[triangle.Length - 1].IsValidate())
                        {
                            ShapeDic.Add($"Triangle{ShapeDic.Count}", triangle.Length - 1);

                            Triangles = triangle;

                            _functions.WriteColor("The shape has been added successfully", ConsoleColor.Green);
                            break;
                        }
                        else
                        {
                            _functions.WriteLineColor("Such a triangle cannot exist",ConsoleColor.Red);
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        _functions.WriteLineColor("Error!!!",ConsoleColor.Red);
                        break;
                    }
                default:
                    _functions.WriteLineColor("Wrong shape", ConsoleColor.Red);
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
                        _functions.WriteLineColor($"{i + 1})Circle", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Radius : {Circles[ShapeDic[$"Circle{i}"]].Radius}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Rectangle{i}"))
                    {
                        _functions.WriteLineColor($"{i + 1})Rectangle", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Side A : {Rectangles[ShapeDic[$"Rectangle{i}"]].A}\n   Side B : {Rectangles[ShapeDic[$"Rectangle{i}"]].B}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Square{i}"))
                    {
                        _functions.WriteLineColor($"{i + 1})Square", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Side : {Squares[ShapeDic[$"Square{i}"]].Side}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Triangle{i}"))
                    {
                        _functions.WriteLineColor($"{i + 1})Triangle", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Side A : {Triangles[ShapeDic[$"Triangle{i}"]].A}\n   Side B : {Triangles[ShapeDic[$"Triangle{i}"]].B}\n   Side C : {Triangles[ShapeDic[$"Triangle{i}"]].C}", ConsoleColor.DarkYellow);
                    }
                    WriteLine();
                }
            }
            else 
            {
                _functions.WriteLineColor("The list of figures is empty :(",ConsoleColor.Red);
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
            _functions.WriteLineColor("The figures have been successfully cleared",ConsoleColor.Green);
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

    }
}
