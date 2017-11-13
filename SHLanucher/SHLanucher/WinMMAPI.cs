using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SHLanucher
{
    internal static class WinMMAPI
    {
        public const int MM_JOY1MOVE = 928;
        public const int MM_JOY2MOVE = 929;
        public const int MM_JOY1ZMOVE = 930;
        public const int MM_JOY2ZMOVE = 931;
        public const int MM_JOY1BUTTONDOWN = 949;
        public const int MM_JOY2BUTTONDOWN = 950;
        public const int MM_JOY1BUTTONUP = 951;
        public const int MM_JOY2BUTTONUP = 952;

        [DllImport("winmm.dll", CharSet = CharSet.Ansi)]
        public static extern ResultCode joyGetDevCapsA(int uJoyID, [In][Out] JOYCAPS pjc, int cbjc);

        [DllImport("winmm.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern int joyGetNumDevs();

        [DllImport("winmm.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern ResultCode joyGetPos(int uJoyID, JOYINFO pji);

        [DllImport("winmm.dll", CharSet = CharSet.None, ExactSpelling = false)]
        public static extern ResultCode joyGetPosEx(int uJoyID, JOYINFOEX pji);

        [DllImport("winmm.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern ResultCode joyReleaseCapture(int uJoyID);

        [DllImport("winmm.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern ResultCode joySetCapture(IntPtr hwnd, int uJoyID, int uPeriod, bool fChanged);

        [Flags]
        public enum JoyButtons : byte
        {
            Button1 = 1,
            Button2 = 2,
            Button3 = 4,
            Button4 = 8,
            Button5 = 16,
            Button6 = 32,
            Button7 = 64,
            Button8 = 128
        }

        private static string GetString(byte[] buffer)
        {
            string str = Encoding.ASCII.GetString(buffer);
            int end = str.IndexOf('\0');
            if (end == 0)
                str = string.Empty;
            if (end > 0)
                str = str.Substring(0, end - 1);

            return str;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 8)]
        public class JOYCAPS
        {
            public short mid;   // 2
            public short pid;   // 4

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            public byte[] name = new byte[32];     // 36

            public int xMin;        
            public int xMax;
            public int yMin;
            public int yMax;
            public int zMin;
            public int zMax;
            public int buttonsNumber;
            public int minPeriod;
            public int maxPeriod;
            public int rMin;
            public int rMax;
            public int uMin;
            public int uMax;
            public int vMin;
            public int vMax;
            public int caps;
            public int axesMax;
            public int axesNumber;
            public int buttonsMax;      // 112

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            public byte[] regKey = new byte[32];       // 144

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260, ArraySubType = UnmanagedType.U1)]
            public byte[] oemVxD = new byte[260];       // 404

            public string Name { get { return GetString(name); } }
            public string RegKey { get { return GetString(regKey); } }
            public string OemVxD { get { return GetString(oemVxD); } }
        }

        public class JOYINFO
        {
            public int xPos;
            public int yPos;
            public int zPos;
            public int buttons;

            public JOYINFO()
            {
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 8)]
        public class JOYINFOEX
        {
            public int size;

            public JoyPosFlags flags;

            public int xPos;
            public int yPos;
            public int zPos;
            public int rPos;
            public int uPos;
            public int vPos;
            public int buttons;
            public int buttonNumber;
            public int pov;
            public int reserved1;
            public int reserved2;

            public JOYINFOEX()
            {
                size = Marshal.SizeOf(this);
            }
        }

        [Flags]
        public enum JoyPosFlags : byte
        {
            ReturnX = 1,
            ReturnY = 2,
            ReturnXY = 3,
            ReturnZ = 4,
            ReturnXYZ = 7,
            ReturnR = 8,
            ReturnXYZR = 15,
            ReturnU = 16,
            ReturnXYZRU = 31,
            ReturnV = 32,
            ReturnXYZRUV = 63,
            ReturnPov = 64,
            ReturnButtons = 128,
            ReturnAll = 255
        }

        public enum ResultCode : uint
        {
            NoError = 0,
            Error = 1,
            BadDeviceID = 2,
            NoDriver = 6,
            InvalidParam = 11,
            JoystickInvalidParam = 165,
            JoystickRequestNotCompleted = 166,
            JoystickUnplugged = 167
        }
    }
}
