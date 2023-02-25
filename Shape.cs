using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Figure_Calculator
{
    class Shape
    {
        protected Functions _functions = new Functions();

        public Circle[] Circles;
        public Rectangle[] Rectangles;
        public Square[] Squares;
        public Triangle[] Triangles;
        public Dictionary<string, int> ShapeDic;
        /// <summary>
        /// Constructor for shapes and a list of shapes
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
        /// Function of adding a new shape
        /// </summary>
        public void AddNewShape()
        {
            string comand;
            Clear();
            _functions.WriteLineColor("Add a shape:",ConsoleColor.Cyan);
            _functions.WriteLineColor("1)Circle",ConsoleColor.Yellow);
            _functions.WriteLineColor("2)Rectangle", ConsoleColor.DarkCyan);
            _functions.WriteLineColor("3)Square", ConsoleColor.Blue);
            _functions.WriteLineColor("4)Triangle", ConsoleColor.DarkGreen);
            _functions.WriteColor("Write shape number : ",ConsoleColor.Blue);
            comand = ReadLine();
            switch (comand)
            {
                case "1":
                    Clear();
                    try
                    {
                        Circle[] circle = new Circle[Circles.Length+1];
                        Circles.CopyTo(circle, 0);

                        _functions.WriteColor("Enter the radius of the circle : ",ConsoleColor.Cyan);
                        circle[circle.Length - 1] = new Circle();
                        circle[circle.Length - 1].Radius = Convert.ToSingle(ReadLine());

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

                        _functions.WriteColor("Enter side A : ",ConsoleColor.Blue);
                        rectangle[rectangle.Length-1].SideA = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side B : ",ConsoleColor.Blue);
                        rectangle[rectangle.Length-1].SideB = Convert.ToSingle(ReadLine());

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

                        

                        _functions.WriteColor("Enter the side of the square : ", ConsoleColor.Blue);
                        square[square.Length - 1] = new Square(Convert.ToSingle(ReadLine()));

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

                        _functions.WriteColor("Enter side A : ", ConsoleColor.Blue);
                        triangle[triangle.Length-1].SideA = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side B : ", ConsoleColor.Blue);
                        triangle[triangle.Length - 1].SideB = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side C : ", ConsoleColor.Blue);
                        triangle[triangle.Length - 1].SideC = Convert.ToSingle(ReadLine());

                        if (triangle[triangle.Length - 1].SideA+ triangle[triangle.Length - 1].SideB>= triangle[triangle.Length - 1].SideC&& triangle[triangle.Length - 1].SideA+ triangle[triangle.Length - 1].SideC>= triangle[triangle.Length - 1].SideB&& triangle[triangle.Length - 1].SideB+ triangle[triangle.Length - 1].SideC>= triangle[triangle.Length - 1].SideA)
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
        /// Function for displaying a complete list of shapes and their parameters
        /// </summary>
        public void OutputAllShapes() 
        {
            Clear();
            for (int i = 0; i < ShapeDic.Count; i++)
            {
                if (ShapeDic.ContainsKey($"Circle{i}"))
                {
                    _functions.WriteLineColor($"{i+1})Circle\n   Radius : {Circles[ShapeDic[$"Circle{i}"]].Radius}",ConsoleColor.Yellow);
                }
                else if (ShapeDic.ContainsKey($"Rectangle{i}"))
                {
                    _functions.WriteLineColor($"{i+1})Rectangle\n   Side A : {Rectangles[ShapeDic[$"Rectangle{i}"]].SideA}\n   Side B : {Rectangles[ShapeDic[$"Rectangle{i}"]].SideB}",ConsoleColor.DarkCyan);
                }
                else if (ShapeDic.ContainsKey($"Square{i}"))
                {
                    _functions.WriteLineColor($"{i + 1})Square\n   Side : {Squares[ShapeDic[$"Square{i}"]].Side}",ConsoleColor.Blue);
                }
                else if (ShapeDic.ContainsKey($"Triangle{i}"))
                {
                    _functions.WriteLineColor($"{i + 1})Triangle\n   Side A : {Triangles[ShapeDic[$"Triangle{i}"]].SideA}\n   Side B : {Triangles[ShapeDic[$"Triangle{i}"]].SideB}\n   Side C : {Triangles[ShapeDic[$"Triangle{i}"]].SideC}",ConsoleColor.DarkGreen);
                }
                WriteLine();
            }
        }
        /// <summary>
        /// Shape cleaning function
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
    }
}
