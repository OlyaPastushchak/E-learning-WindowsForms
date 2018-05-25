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
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Point firstp = new Point();
            

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            firstp = e.Location;
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.DrawEllipse(new Pen(Brushes.Red), firstp.X, firstp.Y, e.X - firstp.X, e.Y - firstp.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
