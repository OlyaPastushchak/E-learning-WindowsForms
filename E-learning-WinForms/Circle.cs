using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace E_learning_WinForms
{
       
    class Circle
    {
        public Point Centre { get; set; }
        public Point Edge { get; set; }
        public Color CircleColor { get; set; }

        public Circle(Point c, Point e)
        {
            Centre = c;
            Edge = e;
            CircleColor = Color.White;
        }
       
        public Circle(){}

        public double Radius()
        {
            return Math.Pow((Centre.X - Edge.X) * (Centre.X - Edge.X) + (Centre.Y - Edge.Y) * (Centre.Y - Edge.Y), 0.5);
        }

        public bool IsCompleted()
        {
            return (Centre!=null && Edge!=null);
        }
    }
}
