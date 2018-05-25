using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace E_learning_WinForms
{
   
    //class Point
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }        
    //}
    
    class Circle
    {
        public Point Centre { get; set; }
        public Point Edge { get; set; }

        public Circle(Point c, Point e)
        {
            Centre = c;
            Edge = e;
        }
        public Circle(){}
    }
}
