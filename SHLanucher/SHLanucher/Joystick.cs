using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHLanucher
{
    public class Joystick
    {
        public int ID = -1;
        public string Name = string.Empty;

        public List<string> Axes = new List<string>();
        public List<string> Buttons = new List<string>();

        private WinMMAPI.JOYCAPS Capabilities = new WinMMAPI.JOYCAPS();

        protected List<int> LastAxisPositions = new List<int>();

        protected static List<Joystick> Devices = new List<Joystick>();

        protected List<int> UpdateAxisState()
        {
            return new List<int>();
        }

        public static Joystick[] GetDevices ()
        {
            if (Devices.Count == 0)
            {
                for(int i = 0; i < WinMMAPI.joyGetNumDevs(); i++)
                {
                    Joystick stick = LoadJoystick(i);
                    if (stick != null)
                        Devices.Add(stick);
                }
            }

            return Devices.ToArray();
        }

        public static string GetAxisLabel(int index)
        {
            switch (index)
            {
                case 0:
                    return "X";
                case 1:
                    return "Y";
                case 2:
                    return "R";
                case 3:
                    return "Z";
                case 4:
                    return "U";
                case 5:
                    return "V";
            }

            return "Axis_" + index.ToString();
        }


        private static Joystick LoadJoystick(int index)
        {
            Joystick stick = new Joystick();
            stick.ID = index;

            WinMMAPI.JOYCAPS caps = new WinMMAPI.JOYCAPS();
            int size = Marshal.SizeOf(caps);

            WinMMAPI.ResultCode result = WinMMAPI.joyGetDevCapsA(i, caps, size);

            if (result != WinMMAPI.ResultCode.NoError || caps.Name == string.Empty)
                return null;


// 
//             {
//                 for (int a = 0; a < caps.axesNumber; a++)
//                     AxisNames.Add(GetAxisLabel(a));
// 
//                 for (int b = 0; b < caps.buttonsNumber; b++)
//                     ButtonNames.Add(GetButtonLabel(b));
//             }

            return stick;
        }

    }
}
