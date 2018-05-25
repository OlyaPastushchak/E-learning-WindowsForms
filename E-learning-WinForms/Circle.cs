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
        public string Name { get; set; }
        public Color CircleColor { get; set; } 

        public Circle(Point c, Point e)
        {
            Centre = c;
            Edge = e;
            Name = "";
            CircleColor = Color.White;
        }
        public Circle(Circle c)
        {
            Centre = c.Centre;
            Edge = c.Edge;
            Name = c.Name;
            CircleColor = c.CircleColor;
        }
       
        public Circle(){}

        public double Radius()
        {
            return Math.Pow((Centre.X - Edge.X) * (Centre.X - Edge.X) + (Centre.Y - Edge.Y) * (Centre.Y - Edge.Y), 0.5);
        }

        //public bool IsCompleted()
        //{
        //    return (Centre!=null && Edge!=null);
        //}
    }
}
