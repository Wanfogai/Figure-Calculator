using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Figure_Calculator
{   
    class Logic
    {
        private Shape _shapes = new Shape();
        private Functions _functions;
        /// <summary>
        /// Logic Constructor
        /// </summary>
        public Logic() 
        {
            _functions = new Functions();
        }
        /// <summary>
        /// Program initialization function (start)
        /// </summary>
        /// <param name="IsStarted">Is Started</param>
        public void StartCalc(bool IsStarted) 
        {
            string comand;
            WriteLine("Welcome To 'Figure Calculator'");
            WriteLine();

            while (IsStarted)
            {
                Clear();
                _functions.WriteLineColor("Available commands :",ConsoleColor.Yellow);
                _functions.WriteLineColor("1)Add a shape",ConsoleColor.Cyan);
                _functions.WriteLineColor("2)Output a list of shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("3)The common area of all shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("4)The common perimeter of all shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("5)The area of the figure",ConsoleColor.Cyan);
                _functions.WriteLineColor("6)The perimeter of the figure", ConsoleColor.Cyan);
                _functions.WriteLineColor("7)Save all shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("8)Upload Shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("9)Clear the list of shapes",ConsoleColor.Cyan);
                _functions.WriteLineColor("10)Exit",ConsoleColor.DarkRed);
                WriteLine(); 
                _functions.WriteColor("Enter the command : ",ConsoleColor.DarkGray);
                comand = ReadLine();
                switch (comand) 
                {
                    case "1":
                        _shapes.AddNewShape();
                        ReadKey();
                        break;
                    case "2":
                        _shapes.OutputAllShapes();
                        ReadKey();
                        break;
                    case "3":
                        _functions.WriteLineColor($"Area of all shape : {_functions.AreaAllShape(_shapes)}",ConsoleColor.Blue);
                        ReadKey();
                        break;
                    case "4":
                        _functions.WriteLineColor($"Perimetr of all shape : {_functions.PerimetrAllShape(_shapes)}", ConsoleColor.Blue);
                        ReadKey();
                        break; 
                    case "5":
                        _shapes.OutputAllShapes();
                        try
                        {
                            int shape;
                            _functions.WriteColor("Enter the shape number : ",ConsoleColor.DarkGray);
                            shape = Convert.ToInt32(ReadLine());
                            if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Circle{shape-1}")
                            {
                                _functions.WriteLineColor($"The area of the {shape}th circle: {_shapes.Circles[_shapes.ShapeDic[$"Circle{shape - 1}"]].Area()}",ConsoleColor.Yellow);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Rectangle{shape-1}")
                            {
                                _functions.WriteLineColor($"The area of the {shape}th rectangle: {_shapes.Rectangles[_shapes.ShapeDic[$"Rectangle{shape - 1}"]].Area()}",ConsoleColor.DarkCyan);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Square{shape - 1}")
                            {
                                _functions.WriteLineColor($"The area of the {shape}th square: {_shapes.Squares[_shapes.ShapeDic[$"Square{shape - 1}"]].Area()}",ConsoleColor.Blue);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Triangle{shape - 1}")
                            {
                                _functions.WriteLineColor($"The area of the {shape}th triangle: {_shapes.Triangles[_shapes.ShapeDic[$"Triangle{shape - 1}"]].Area()}",ConsoleColor.DarkGreen);
                            }
                            ReadKey();
                        }
                        catch (Exception)
                        {
                            _functions.WriteLineColor("Error!!!",ConsoleColor.Red);
                            ReadKey();
                            break;
                        }
                        break; 
                    case "6":
                        _shapes.OutputAllShapes();
                        try
                        {
                            int shape;
                            _functions.WriteColor("Enter the shape number : ",ConsoleColor.DarkGray);
                            shape = Convert.ToInt32(ReadLine());
                            if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Circle{shape - 1}")
                            {
                                _functions.WriteLineColor($"The perimeter of the {shape}th circle: {_shapes.Circles[_shapes.ShapeDic[$"Circle{shape - 1}"]].Perimeter()}",ConsoleColor.Yellow);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Rectangle{shape - 1}")
                            {
                                _functions.WriteLineColor($"The perimeter of the {shape}th rectangle: {_shapes.Rectangles[_shapes.ShapeDic[$"Rectangle{shape - 1}"]].Perimeter()}",ConsoleColor.DarkCyan);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Square{shape - 1}")
                            {
                                _functions.WriteLineColor($"The perimeter of the {shape}th square: {_shapes.Squares[_shapes.ShapeDic[$"Square{shape - 1}"]].Perimeter()}",ConsoleColor.Blue);
                            }
                            else if (_shapes.ShapeDic.Keys.ElementAt(shape - 1) == $"Triangle{shape - 1}")
                            {
                                _functions.WriteLineColor($"The perimeter of the {shape}th triangle: {_shapes.Triangles[_shapes.ShapeDic[$"Triangle{shape - 1}"]].Perimeter()}", ConsoleColor.DarkGreen);
                            }
                            ReadKey();
                        }
                        catch (Exception)
                        {
                            _functions.WriteLineColor("Error!!!",ConsoleColor.Red);
                            ReadKey();
                            break;
                        }
                        break;
                    case "7":
                        try
                        {
                            _functions.WriteToFile(_shapes, AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
                            _functions.WriteLineColor("Shapes saved successfully :)", ConsoleColor.Green);
                            ReadKey();
                        }
                        catch (Exception)
                        {
                             _functions.WriteLineColor("Failed to save shapes :(", ConsoleColor.Red);
                             ReadKey();
                            break;
                        }
                        break;
                    case "8":
                        try
                        {
                            _functions.UploadShapes(ref _shapes, AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
                            _functions.WriteLineColor("The shapes are loaded :)", ConsoleColor.Green);
                            ReadKey();
                        }
                        catch (Exception)
                        {
                            _functions.WriteLineColor("Failed to load shapes :(", ConsoleColor.Red);
                            ReadKey();
                            break;
                        }
                        break;
                    case "9":
                        _shapes.ClearShapes();
                        break;
                    case "10":
                        IsStarted = false;
                        _functions.WriteLineColor("Good bye ^_^",ConsoleColor.Yellow);
                        ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
