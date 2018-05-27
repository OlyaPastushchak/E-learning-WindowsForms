using System;
using System.Drawing;
using System.Windows.Forms;


namespace E_learning_WinForms
{
    interface IShape
    {
        void Move(MouseEventArgs mouseEvent);
        void Draw(Graphics graphics);
    }
}
