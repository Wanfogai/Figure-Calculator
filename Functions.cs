using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Newtonsoft.Json;

namespace Figure_Calculator
{
    class Functions
    {
        public Shape Shape;
        /// <summary>
        /// Output a colored line (by default it is white) and move the cursor to the next line
        /// </summary>
        /// <param name="text">The text to be output</param>
        /// <param name="color">Text color</param>
        public void WriteLineColor(string text, ConsoleColor color = ConsoleColor.White) 
        {
            ForegroundColor = color;
            WriteLine(text);
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Output a colored line (by default it is white)
        /// </summary>
        /// <param name="text">The text to be output</param>
        /// <param name="color">Text color</param>
        public void WriteColor(string text, ConsoleColor color = ConsoleColor.White)
        {
            ForegroundColor = color;
            Write(text);
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Writes the Shapes object to a .json file
        /// </summary>
        /// <param name="Shapes">Shapes Object</param>
        /// <param name="Path">File path</param>
        public void WriteToFile(Shape Shapes, string Path) 
        {
            string json = JsonConvert.SerializeObject(Shapes);

            File.Delete(Path);

            File.AppendAllText(Path,json);
        }
        /// <summary>
        /// Loads the Shapes object from a .json file
        /// </summary>
        /// <param name="Shapes">Shapes Object</param>
        /// <param name="Path">File path</param>
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
        /// Finds the common perimeter of the shapes
        /// </summary>
        /// <param name="shape">Figure</param>
        /// <returns></returns>
        public float PerimetrAllShape(Shape shape)
        {
            float Perimetr=0;
            foreach (var item in shape.Circles)
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in shape.Rectangles) 
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in shape.Squares) 
            {
                Perimetr += item.Perimeter();
            }
            foreach (var item in shape.Triangles) 
            {
                Perimetr += item.Perimeter();
            }
            return Perimetr;
        }
        /// <summary>
        /// Finds the total perimeter of the shapes
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>Figure</returns>
        public float AreaAllShape(Shape shape)
        {
            float Area = 0;
            foreach (var item in shape.Circles)
            {
                Area += (!item.Equals(null))? item.Area()  : 0;
            }
            foreach (var item in shape.Rectangles)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            foreach (var item in shape.Squares)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            foreach (var item in shape.Triangles)
            {
                Area += (!item.Equals(null)) ? item.Area() : 0;
            }
            return Area;
        }
    }
}
