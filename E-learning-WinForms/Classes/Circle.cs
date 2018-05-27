using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace E_learning_WinForms
{
       [Serializable]
    public class Circle
    {
        public Point Centre { get; set; }
        public Point Edge { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public Color CircleColor { get; set; }

        [XmlElement("CircleColor")]
        public int ColorArgb
        {
            get { return CircleColor.ToArgb(); }
            set { CircleColor = Color.FromArgb(value); }
        }


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

        public Circle()
        {
            Centre = new Point();
            Edge = new Point();
            Name = "";
            CircleColor = new Color();
        }

        public double Radius()
        {
            return Math.Pow((Centre.X - Edge.X) * (Centre.X - Edge.X) + (Centre.Y - Edge.Y) * (Centre.Y - Edge.Y), 0.5);
        }

      

    }
}
