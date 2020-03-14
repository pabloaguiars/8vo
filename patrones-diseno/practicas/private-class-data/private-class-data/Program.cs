using System;
using System.Collections.Generic;

namespace private_class_data
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure figure = new Figure("RED", new List<float>() { 5, 4, 9, 8, 7 });
            Console.WriteLine("Color: " + figure.GetColor().ToString());
            Console.WriteLine("Perimeter: " + figure.GetPerimeter().ToString());
            List<float> sides = figure.GetSides();

            Console.WriteLine("Sides: ");
            foreach (float side in sides)
            {
                Console.Write(side.ToString() + ", ");
            }

            Console.ReadKey();
        }
    }

    class Figure
    {
        private FigureData data;
        public Figure(string Color, List<float> Sides)
        {
            data = new FigureData(Color, Sides);
        }

        public string GetColor()
        {
            return data.GetColor();
        }

        public float GetPerimeter()
        {
            return data.GetPerimeter();
        }

        public List<float> GetSides()
        {
            return data.GetSides();
        }
    }

    class FigureData
    {
        private string Color { get; set; }
        private List<float> Sides { get; set; }
        private float Perimeter { get; set; }

        public FigureData(string Color, List<float> Sides)
        {
            this.Color = Color;
            this.Sides = Sides;

            this.Perimeter = CalculatePerimeter();
        }

        private float CalculatePerimeter()
        {
            float sum = 0;
            foreach (float Side in Sides)
            {
                sum += Side;
            }

            return sum;
        }

        public float GetPerimeter()
        {
            Perimeter = CalculatePerimeter();
            return Perimeter;
        }

        public List<float> GetSides()
        {
            return Sides;
        }

        public void AddSide(float Side)
        {
            Sides.Add(Side);
            Perimeter = CalculatePerimeter();
        }

        public string GetColor()
        {
            return Color;
        }
    }
}
