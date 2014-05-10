using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedRenamer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DirectoryInfo dir = null;
            if (args.Length > 0)
            {
                // Navigate to the input directory
                try
                {
                    dir = new DirectoryInfo(args[0]);
                }
                catch { }
            }

            Application.Run(new FrmMain(dir));
        }
    }
}
