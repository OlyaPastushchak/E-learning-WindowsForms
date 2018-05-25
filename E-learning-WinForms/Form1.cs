using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_learning_WinForms
{
    public partial class Form1 : Form
    {
        private static int countPoints;
        private Circle newCircle;
        private List<Circle> drawenCircles;

        public Form1()
        {
            InitializeComponent();
            newCircle = new Circle();
            drawenCircles = new List<Circle>();
            countPoints = 0;
        }



        
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            countPoints++;
            var p = sender as Panel;
            Graphics g = p.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3);
            Brush pointBrush = (Brush)Brushes.Black;
            int pointX = ((MouseEventArgs)e).X;
            int pointY = ((MouseEventArgs)e).Y;
            g.FillRectangle(pointBrush, pointX, pointY, 2, 2);//draws a point
            
            if (countPoints % 2 == 1)
            {
                newCircle.Centre = new Point(pointX, pointY);
            }
            else
            {
                newCircle.Edge = new Point(pointX, pointY);               
                double radius = newCircle.Radius();
                g.DrawEllipse(pen, (float)(newCircle.Centre.X -radius), (float)(newCircle.Centre.Y-radius), (float)(radius * 2), (float)(radius * 2));

                drawenCircles.Add(newCircle);

                
                ColorDialog colorDialog1 = new ColorDialog();
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                   g.FillEllipse(new SolidBrush(colorDialog1.Color), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));

                }
            }
            
        }
    }
}
