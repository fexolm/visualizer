using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Visualizer.Parser.Implementation;

namespace Visualizer
{
    static partial class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Visualizer());
        }
    }
}
