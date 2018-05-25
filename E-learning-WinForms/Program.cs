using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_learning_WinForms
{
    static class Program
    {
        class MyForm : Form
        {
            Button button1 = new Button();
            Label label1 = new Label();

            public MyForm()
            {
                this.Controls.Add(button1);
                this.Controls.Add(label1);
            }  
        }
        
        class MyApp
        {
            public static void App()
            {
                MyForm form = new MyForm();

                Application.Run(form);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // MyApp.App();
            Application.Run(new Form1());
        }
    }
}
