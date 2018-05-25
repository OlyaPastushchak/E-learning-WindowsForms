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
        private Circle currentCircle;
        private List<Circle> drawenCircles;

        public Form1()
        {
            InitializeComponent();
            newCircle = new Circle();
            currentCircle = new Circle();
            drawenCircles = new List<Circle>();
            countPoints = 0;
        }


        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
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

                               
                ColorDialog colorDialog1 = new ColorDialog();
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    newCircle.CircleColor = colorDialog1.Color;
                    g.DrawEllipse(new Pen(colorDialog1.Color,3), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                    g.FillEllipse(new SolidBrush(colorDialog1.Color), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                }

                newCircle.Name = ShowDialog("Please enter name for circle", "Name for circle");
                drawenCircles.Add(new Circle(newCircle));
                ToolStripItem subItem = new ToolStripMenuItem(newCircle.Name);
                shapesToolStripMenuItem.DropDownItems.Add(subItem);
            }
            
        }


       
        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent.Button == MouseButtons.Right)
            {
                var p = sender as Panel;
                Graphics g = p.CreateGraphics();
                int newCentreX = ((MouseEventArgs)e).X;
                int newCentreY = ((MouseEventArgs)e).Y;
                double radius = currentCircle.Radius();
                int newEdgeX = newCentreX - (int)radius;
                int newEdgeY = newCentreY;

                g.FillEllipse(new SolidBrush(Color.White), (float)(currentCircle.Centre.X - radius), (float)(currentCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                g.DrawEllipse(new Pen(Color.White, 3), (float)(currentCircle.Centre.X - radius), (float)(currentCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                currentCircle.Centre = new Point(newCentreX, newCentreY);
                currentCircle.Edge = new Point(newEdgeX, newEdgeY);
                g.FillEllipse(new SolidBrush(currentCircle.CircleColor), (float)(currentCircle.Centre.X - radius), (float)(currentCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
            }
        }

        private void shapesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedname = e.ClickedItem.Text;
            MessageBox.Show(clickedname);
            currentCircle = drawenCircles.Find(x => x.Name == clickedname);            
        }
    }
}
