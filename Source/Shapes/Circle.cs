using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Circle
    {
        public float Radius { get; set;}
        /// <summary>
        /// Shape : Circle
        /// </summary>
        /// <param name="Radius">Radius of the Circle</param>
        public Circle(float Radius) 
        {
            this.Radius = Radius;
        }
        /// <summary>
        /// Shape : Circle
        /// Without parameters
        /// </summary>
        public Circle() 
        {

        }
        /// <summary>
        /// A function that performs calculations of the area of Circles
        /// </summary>
        /// <returns>Returns the area of the Circle</returns>
        public float Area() 
        {
            return Convert.ToSingle(Round(PI * Pow(Radius, 2),2));
        }
        /// <summary>
        /// The function of finding the perimeter of a Circle
        /// </summary>
        /// <returns>Returns the perimeter of the Circle</returns>
        public float Perimeter() 
        {
            return Convert.ToSingle(Round(2 * PI * Radius, 2));
        }
    }
}
