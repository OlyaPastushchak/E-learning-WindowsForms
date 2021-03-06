﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


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
            newCircle = new Circle();
            currentCircle = null;
            drawenCircles = new List<Circle>();
            graphics = panel1.CreateGraphics();
            countPoints = 0;
        }

        public void DrawCircles(List<Circle> circles)
        {
            panel1.Refresh();
            shapesToolStripMenuItem.DropDownItems.Clear();
            foreach (var circle in circles)
            {
                circle.Draw(graphics);
                ToolStripItem subItem = new ToolStripMenuItem(circle.Name);
                shapesToolStripMenuItem.DropDownItems.Add(subItem);
            }
            if (currentCircle != null)
            {
                currentCircle.Draw(graphics);
                currentCircle = null;
            }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent.Button == MouseButtons.Right)
            {
                if (currentCircle == null)
                {
                    MessageBox.Show("You haven't chosen the active figure. To choose select it from Shapes drop-down list.", "No active figure");
                }
                else
                {
                    currentCircle.Move(mouseEvent);
                    Circle active = currentCircle;

                    DrawCircles(drawenCircles);
                    currentCircle = active;
                }
            }
        }

        private void Panel1_DoubleClick(object sender, EventArgs e)
        {
            countPoints++;
            var p = sender as Panel;
            Point drawenPoint = Drawing.DrawPoint(p, graphics, e);

            if (countPoints % 2 == 1)
            {
                newCircle.Centre = drawenPoint;
            }
            else
            {
                newCircle.Edge = drawenPoint;
                Drawing.DrawNewCircle(graphics, ref newCircle);

                drawenCircles.Add(new Circle(newCircle));
                ToolStripItem subItem = new ToolStripMenuItem(newCircle.Name);
                shapesToolStripMenuItem.DropDownItems.Add(subItem);
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            shapesToolStripMenuItem.DropDownItems.Clear();
            currentCircle = null;
            drawenCircles = new List<Circle>();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "(*.xml)|*.xml",
                CheckFileExists = true,
                Title = "Choose file to open"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<Circle> deserializedCircles = Serialization.DeserializeFromXML(openFileDialog1.FileName);
                currentCircle = null;
                DrawCircles(deserializedCircles);
                drawenCircles = deserializedCircles;
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                Title = "Save file with circles"
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Serialization.SerializeInXML(saveFileDialog1.FileName, drawenCircles);
            }
        }

        private void ShapesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedname = e.ClickedItem.Text;
            currentCircle = drawenCircles.Find(x => x.Name == clickedname);
        }
    }
}
