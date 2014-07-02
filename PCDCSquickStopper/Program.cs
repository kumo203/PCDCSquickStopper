using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SendApp
{
    class Program
    {
        readonly static uint SW_SHOWNORMAL = 1;
        readonly static uint WM_CLOSE = 0x10;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, uint nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        static void Main(string[] args)
        {
            foreach (var p in Process.GetProcesses())
            {
                Debug.WriteLine(p.ProcessName);
                if ((p.ProcessName == "hke") || (p.ProcessName == "DeviceXPlorer"))
                {
                    p.Kill();
                }
            }

            IntPtr hTaskBar = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hTaskBar, SW_SHOWNORMAL); 
        }
    }
}
