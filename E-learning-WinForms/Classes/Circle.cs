using System;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;


namespace E_learning_WinForms
{
    [Serializable]
    public class Circle : IShape
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

        public void Draw(Graphics graphics)
        {
            double radius = this.Radius();
            graphics.DrawEllipse(new Pen(this.CircleColor, 3), (float)(this.Centre.X - radius), (float)(this.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
            graphics.FillEllipse(new SolidBrush(this.CircleColor), (float)(this.Centre.X - radius), (float)(this.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
        }

        public void Move(MouseEventArgs mouseEvent)
        {
            int newCentreX = mouseEvent.X;
            int newCentreY = mouseEvent.Y;
            double radius = this.Radius();
            int newEdgeX = newCentreX - (int)radius;
            int newEdgeY = newCentreY;

            this.Centre = new Point(newCentreX, newCentreY);
            this.Edge = new Point(newEdgeX, newEdgeY);
        }
    }
}
