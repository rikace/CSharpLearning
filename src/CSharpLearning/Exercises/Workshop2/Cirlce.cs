using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop2
{
    // CODE HERE
    public struct Circle
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Area => Math.PI * Radius * Radius;

        public static Circle operator +(Circle circle1, Circle circle2)
        {
            var newArea = circle1.Area + circle2.Area;
            var newRadius = Math.Sqrt((newArea / Math.PI));

            return new Circle(newRadius);
        }
    }
}
   

