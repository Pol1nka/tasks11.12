using System;

namespace points
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Point pointTest = new Point(5, -10);
            pointTest.Flip();
            
            Point point1 = new Point(10, 10);
            point1.Flip();
            Point point2 = new Point(-5, -8);
            
            // Console.WriteLine($"Перевернутые координаты тестовой точки: {pointTest.ToString()}");
            Console.WriteLine($"Расстояние между точкой один и точкой два: {point1.Distance(point2)}");
            
            Console.ReadLine();
        }

        public class Point
        {
            private double _x;
            private double _y;

            public Point(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public void Flip()
            {
                double tempY = _y;
                double tempX = _x;
                _x = tempY * -1;
                _y = tempX * -1;
            }

            public double Distance(Point point)
            {
                return Math.Sqrt(Math.Pow(point._x - _x, 2) + Math.Pow(point._y - _y, 2));
            }

            public override string ToString()
            {
                return $"({_x}, {_y})";
            }
        }
    }
}