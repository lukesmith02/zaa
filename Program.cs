using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Jitter j = new Jitter();
            System.Threading.Thread myThread;
            myThread = new System.Threading.Thread(new
   System.Threading.ThreadStart(j.myStartingMethod));
            myThread.Start();
            Application.Run(j);
            myThread.Abort();
        }
    }
}
