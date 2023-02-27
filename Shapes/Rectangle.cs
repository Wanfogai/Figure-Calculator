using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Rectangle
    {
        public float SideA { get; set;}
        public float SideB { get; set;}
        /// <summary>
        /// Shape : Rectangle
        /// </summary>
        /// <param name="SideA">Side A of the Rectangle</param>
        /// <param name="SideB">Side B of the Rectangle</param>
        public Rectangle(float SideA, float SideB) 
        {
            this.SideA = SideA;
            this.SideB = SideB;
        }
        /// <summary>
        /// Shape : Rectangle
        /// Without parameters
        /// </summary>
        public Rectangle() 
        {

        }
        /// <summary>
        /// A function that performs calculations of the area of Rectangles
        /// </summary>
        /// <returns>Returns the area of the Rectangle</returns>
        public float Area() 
        {
            return Convert.ToSingle(Round(SideA*SideB,2));
        }
        /// <summary>
        /// The function of finding the perimeter of a Rectangle
        /// </summary>
        /// <returns>Returns the perimeter of the Rectangle</returns>
        public float Perimeter() 
        {
            return Convert.ToSingle(Round((SideA+SideB)*2,2));
        }
    }
}
