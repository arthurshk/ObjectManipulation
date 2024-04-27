﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poolhall.Model
{
    public class Ball
    {
        public int Id { get; set; }
        public Color Color { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public Ball(int id, Color color, double x, double y, double radius)
        {
            Id = id;
            Color = color;
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
