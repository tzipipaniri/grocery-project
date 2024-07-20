using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using פרויקט.Dal;
using פרויקט.BLL;
using פרויקט.Gui;

namespace פרויקט
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Customers s=new Customers();
            Application.Run(new Form1());
        }
    }
}
