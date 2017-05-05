using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Jitter : Form
    {
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        Boolean pauseVar = true;
        public Jitter()
        {
            InitializeComponent();
        }

        public static void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);

        }

        public void myStartingMethod()
        {
            while (true)
            {
                Boolean b = getPauseVar();
                int xx = 0;
                int yy = 0;
                /*
                POINT lpPoint;
                GetCursorPos(out lpPoint);
                int x = lpPoint.X + 1;
                int y = lpPoint.Y + 1;
                MoveMouse(x, y);
                */
                /*
                POINT lpPoint;
                GetCursorPos(out lpPoint);
                int x = lpPoint.X - 1;
                int y = lpPoint.Y - 1;
                MoveMouse(x, y);
                */
                if (b)
                    System.Threading.Thread.Sleep(500);
                b = getPauseVar();
                if (b)
                    xx = 2;
                b = getPauseVar();
                if (b)
                    yy = 2;
                b = getPauseVar();
                if (b)
                    mouse_event(MOUSEEVENTF_MOVE, xx, yy, 0, 0);
                b = getPauseVar();
                if (b)
                    System.Threading.Thread.Sleep(500);
                b = getPauseVar();
                if (b)
                    System.Threading.Thread.Sleep(500);
                b = getPauseVar();
                if (b)
                    xx = -2;
                b = getPauseVar();
                if (b)
                    yy = -2;
                b = getPauseVar();
                if (b)
                    mouse_event(MOUSEEVENTF_MOVE, xx, yy, 0, 0);
                b = getPauseVar();
                if (b)
                    System.Threading.Thread.Sleep(500);

            }

        }

        private void Jitter_Load(object sender, EventArgs e)
        {

        }

        public Boolean getPauseVar()
        {
            return this.pauseVar;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pause_Click(object sender, EventArgs e)
        {
            this.pauseVar = false;
        }

        private void unpause_Click(object sender, EventArgs e)
        {
            this.pauseVar = true;
        }
    }
}
