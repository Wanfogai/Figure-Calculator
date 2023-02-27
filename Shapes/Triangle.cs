using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Figure_Calculator
{
    class Triangle
    {
        public float SideA { get; set;}
        public float SideB { get; set;}
        public float SideC { get; set;}
        /// <summary>
        /// Shape : Triangle
        /// </summary>
        /// <param name="SideA">Side A</param>
        /// <param name="SideB">Side B</param>
        /// <param name="SideC">Side C</param>
        public Triangle(float SideA, float SideB, float SideC) 
        {
            this.SideA = SideA;
            this.SideB = SideB;
            this.SideC = SideC;
        }
        /// <summary>
        /// Shape : Triangle
        /// Without parameters
        /// </summary>
        public Triangle() 
        {

        }
        /// <summary>
        /// A function that performs calculations of the area of triangles
        /// </summary>
        /// <returns>Returns the area of the triangle</returns>
        public float Area() 
        {
                if (SideA == SideB && SideB == SideC)
                {
                    return Convert.ToSingle(Round((Pow(SideA, 2) * Sqrt(3)) / 4, 2));
                }
                else if (SideA == SideB || SideA == SideC || SideB == SideC)
                {
                    if (SideA == SideB)
                    {
                        return Convert.ToSingle(Round((Convert.ToDouble(SideC) / 4) * Sqrt(4 * Pow(SideA, 2) - Pow(SideC, 2)), 2));
                    }
                    else if (SideA == SideC)
                    {
                        return Convert.ToSingle(Round((Convert.ToDouble(SideC) / 4) * Sqrt(4 * Pow(SideA, 2) - Pow(SideC, 2)), 2));
                    }
                    else
                    {
                        return Convert.ToSingle(Round((Convert.ToDouble(SideC) / 4) * Sqrt(4 * Pow(SideA, 2) - Pow(SideC, 2)), 2));
                    }
                }
                else
                {
                    float P;
                    P = (SideA + SideB + SideC) / 2;
                    return Convert.ToSingle(Round(Sqrt(P * (P - SideA) * (P - SideB) * (P - SideC)), 2));
                }
        }
        /// <summary>
        /// The function of finding the perimeter of a triangle
        /// </summary>
        /// <returns>Returns the perimeter of the triangle</returns>
        public float Perimeter() 
        {
            return Convert.ToSingle(Round(SideA + SideB + SideC,2));
        }

    }
}
