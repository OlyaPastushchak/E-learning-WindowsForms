﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace E_learning_WinForms
{
    public partial class Form1 : Form
    {
        private static int countPoints;
        private Circle newCircle;
        private Circle currentCircle;
        private List<Circle> drawenCircles;
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            newCircle = new Circle(new Point(),new Point());
            currentCircle = null;
            drawenCircles = new List<Circle>();
            graphics = panel1.CreateGraphics();
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
            Pen pen = new Pen(Color.Black, 3);
            Brush pointBrush = (Brush)Brushes.Black;
            int pointX = ((MouseEventArgs)e).X;
            int pointY = ((MouseEventArgs)e).Y;
            graphics.FillRectangle(pointBrush, pointX, pointY, 2, 2);//draws a point
            
            if (countPoints % 2 == 1)
            {
                newCircle.Centre = new Point(pointX, pointY);
            }
            else
            {
                newCircle.Edge = new Point(pointX, pointY);               
                double radius = newCircle.Radius();
                graphics.DrawEllipse(pen, (float)(newCircle.Centre.X -radius), (float)(newCircle.Centre.Y-radius), (float)(radius * 2), (float)(radius * 2));

                               
                ColorDialog colorDialog1 = new ColorDialog();
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    newCircle.CircleColor = colorDialog1.Color;
                    graphics.DrawEllipse(new Pen(colorDialog1.Color,3), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                    graphics.FillEllipse(new SolidBrush(colorDialog1.Color), (float)(newCircle.Centre.X - radius), (float)(newCircle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
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
                if (currentCircle == null)
                {
                    MessageBox.Show("You haven't chosen the active figure. To choose select it from Shapes drop-down list.","No active figure");
                }
                else
                {
                    int newCentreX = ((MouseEventArgs)e).X;
                    int newCentreY = ((MouseEventArgs)e).Y;
                    double radius = currentCircle.Radius();
                    int newEdgeX = newCentreX - (int)radius;
                    int newEdgeY = newCentreY;

                    currentCircle.Centre = new Point(newCentreX, newCentreY);
                    currentCircle.Edge = new Point(newEdgeX, newEdgeY);
                    Circle active = currentCircle;
                    
                    DrawCircles(panel1, drawenCircles);
                    currentCircle = active;
                }
            }
        }

        private void shapesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedname = e.ClickedItem.Text;
            currentCircle = drawenCircles.Find(x => x.Name == clickedname);            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            shapesToolStripMenuItem.DropDownItems.Clear();
            currentCircle = null;
            drawenCircles = null;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Title = "Save file with circles";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Circle>));
                Stream serialStream = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                xmlser.Serialize(serialStream, drawenCircles);
            }          
        }


        public void DrawCircles(Panel panel, List<Circle> circles)
        {
            panel.Refresh();
            
            shapesToolStripMenuItem.DropDownItems.Clear();
            foreach (var circle in circles)
            {
                double radius = circle.Radius();
                graphics.FillEllipse(new SolidBrush(circle.CircleColor), (float)(circle.Centre.X - radius), (float)(circle.Centre.Y - radius), (float)(radius * 2), (float)(radius * 2));
                ToolStripItem subItem = new ToolStripMenuItem(circle.Name);
                shapesToolStripMenuItem.DropDownItems.Add(subItem);
            }
            if (currentCircle != null)
            {
                double currentCircleRadius = currentCircle.Radius();
                graphics.FillEllipse(new SolidBrush(currentCircle.CircleColor), (float)(currentCircle.Centre.X - currentCircleRadius), (float)(currentCircle.Centre.Y - currentCircleRadius), (float)(currentCircleRadius * 2), (float)(currentCircleRadius * 2));

                currentCircle = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(*.xml)|*.xml";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "Choose file to open";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                List<Circle> deserializedCircles = null;
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Circle>));
                using (FileStream serialStream = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    deserializedCircles = (List<Circle>)xmlser.Deserialize(serialStream);
                }

                if (deserializedCircles == null)
                {
                    throw new ApplicationException(string.Format("cannot deserialize file {0}", openFileDialog1.FileName));
                }
                currentCircle = null;
                DrawCircles(panel1, deserializedCircles);
                drawenCircles = deserializedCircles;
            }
        }
    }
}
