using System;
using System.Runtime.InteropServices;

namespace SCR_Repair_Tracker
{
    public class IdleTimeChecker  // code copied from internet,  we only care about get inactivetime method
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);



        public TimeSpan? GetInactiveTime() // this method gets idle time since last user input
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            if (GetLastInputInfo(ref info))
                return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
            else
                return null;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
}
