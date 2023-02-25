using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Square
    {
        public float Side { get; set; }
        /// <summary>
        /// Shape : Square
        /// </summary>
        /// <param name="Side">Side of the Square</param>
        public Square(float Side)
        {
            this.Side = Side;
        }
        /// <summary>
        /// Shape : Square
        /// Without parameters
        /// </summary>
        public Square() 
        {

        }
        /// <summary>
        /// A function that performs calculations of the area of Squares
        /// </summary>
        /// <returns>Returns the area of the Square</returns>
        public float Area() 
        {
            return Convert.ToSingle(Round(Pow(Side,2),2));
        }
        /// <summary>
        /// The function of finding the perimeter of a Square
        /// </summary>
        /// <returns>Returns the perimeter of the Square</returns>
        public float Perimeter() 
        {
            return Convert.ToSingle(Round(Side*4,2)); 
        }


    }
}
