using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poolhall.Model
{
    public class Circle
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Radius { get; private set; }

        public Circle(double radius, double x, double y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }
    }
}
