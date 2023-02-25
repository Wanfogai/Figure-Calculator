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

                        _functions.WriteColor("Enter side A : ",ConsoleColor.DarkGray);
                        rectangle[rectangle.Length-1].SideA = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side B : ",ConsoleColor.DarkGray);
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

                        

                        _functions.WriteColor("Enter the side of the square : ", ConsoleColor.DarkGray);
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

                        _functions.WriteColor("Enter side A : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length-1].SideA = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side B : ", ConsoleColor.DarkGray);
                        triangle[triangle.Length - 1].SideB = Convert.ToSingle(ReadLine());
                        _functions.WriteColor("Enter side C : ", ConsoleColor.DarkGray);
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
                        _functions.WriteLineColor($"   Side A : {Rectangles[ShapeDic[$"Rectangle{i}"]].SideA}\n   Side B : {Rectangles[ShapeDic[$"Rectangle{i}"]].SideB}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Square{i}"))
                    {
                        _functions.WriteLineColor($"{i + 1})Square", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Side : {Squares[ShapeDic[$"Square{i}"]].Side}", ConsoleColor.DarkYellow);
                    }
                    else if (ShapeDic.ContainsKey($"Triangle{i}"))
                    {
                        _functions.WriteLineColor($"{i + 1})Triangle", ConsoleColor.Yellow);
                        _functions.WriteLineColor($"   Side A : {Triangles[ShapeDic[$"Triangle{i}"]].SideA}\n   Side B : {Triangles[ShapeDic[$"Triangle{i}"]].SideB}\n   Side C : {Triangles[ShapeDic[$"Triangle{i}"]].SideC}", ConsoleColor.DarkYellow);
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
