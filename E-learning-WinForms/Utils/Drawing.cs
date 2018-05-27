using System;
using System.Drawing;
using System.Windows.Forms;

namespace E_learning_WinForms
{
    class Drawing
    {
        public static Point DrawPoint(Panel panel, Graphics graphics, EventArgs e)
        {
            Brush pointBrush = Brushes.Black;
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            int pointX = mouseEvent.X;
            int pointY = mouseEvent.Y;
            const int pointHeigh = 2;
            const int pointWidth = 2;
            Point drawenPoint = new Point(pointX, pointY);
            graphics.FillRectangle(pointBrush, pointX, pointY, pointHeigh, pointWidth);//draws a point

            return drawenPoint;
        }

        public static void DrawNewCircle(Graphics graphics, ref Circle newCircle)
        {
            double radius = newCircle.Radius();
            graphics.DrawEllipse(new Pen(Color.Black, 3), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));

            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                newCircle.CircleColor = colorDialog1.Color;
                graphics.DrawEllipse(new Pen(colorDialog1.Color, 3), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                graphics.FillEllipse(new SolidBrush(colorDialog1.Color), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
            }
            newCircle.Name = Utils.ShowDialog("Please enter name for circle", "Name for circle");

        }
    }
}
