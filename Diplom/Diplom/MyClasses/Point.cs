using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    abstract class Point
    {
        public Point(int y, int x)
        {
            X = y;
            Y = x;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public static Double N
        {
            get { return 1.38 * Math.Pow(10, -23) * 400 * 271000; }
        }

        public static double Distance(Point m, Point n)
        {
            return Math.Sqrt(Math.Pow((m.X - n.X), 2) + Math.Pow((m.Y - n.Y), 2));
        }
        // Из Ват в дБ
        protected double ToDB(double vat)
        {
            return 10 * Math.Log10(vat);
        }
       
        // Из дБ в Ват
        protected double ToVat(double db)
        {
            return Math.Pow(10, db / 10);
        }
    }
}
