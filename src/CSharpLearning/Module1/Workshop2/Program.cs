using System;

namespace Workshop2
{
    
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


    public static class Solution
    {
        public static void Main()
        {
            var circle1 = new Circle(3);
            var circle2 = new Circle(3);
            var circle3 = circle1 + circle2;

            Console.WriteLine($"Adding circles of radius of {circle1.Radius} and {circle2.Radius} " + $"results in a new circle with a radius {circle3.Radius} ");
        }
    }
}