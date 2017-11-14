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

        protected List<double> LastAxisPositions = new List<double>();
        protected List<bool> LastButtonStates = new List<bool>();

        protected static List<Joystick> Devices = new List<Joystick>();

        private List<double> UpdateAxisState(WinMMAPI.JOYINFOEX info)
        {
            List<double> axisVals = new List<double>();


            if (Capabilities.axesNumber >= 1)
                axisVals.Add(MakeParametric(info.xPos, Capabilities.xMin, Capabilities.xMax));
            if (Capabilities.axesNumber >= 2)
                axisVals.Add(MakeParametric(info.yPos, Capabilities.yMin, Capabilities.yMax));
            if (Capabilities.axesNumber >= 3)
                axisVals.Add(MakeParametric(info.rPos, Capabilities.rMin, Capabilities.rMax));
            if (Capabilities.axesNumber >= 4)
                axisVals.Add(MakeParametric(info.zPos, Capabilities.zMin, Capabilities.zMax));
            if (Capabilities.axesNumber >= 5)
                axisVals.Add(MakeParametric(info.uPos, Capabilities.uMin, Capabilities.uMax));
            if (Capabilities.axesNumber >= 6)
                axisVals.Add(MakeParametric(info.vPos, Capabilities.vMin, Capabilities.vMax));

            return axisVals;
        }

        private List<bool> UpdateButtonState(WinMMAPI.JOYINFOEX info)
        {
            List<bool> axisVals = new List<bool>();

            for (int i = 0; i < Capabilities.buttonsNumber; i++)
            {
                int mask = (int)(Math.Pow(2, i));
                if (mask == 0)
                    mask = 1;

                axisVals.Add(((info.buttons & mask) != 0));
            }

            return axisVals;
        }

        protected double MakeParametric(int val, int min, int max)
        {
            if (max == 0)
                return 0;

            int range = max - min;
            double param = (val - min) / range;
            return (param * 2) - 1.0;
        }

        public void StartCapture()
        {
            WinMMAPI.JOYINFOEX info = new WinMMAPI.JOYINFOEX();
            info.flags = WinMMAPI.JoyPosFlags.ReturnAll;

            WinMMAPI.joyGetPosEx(ID, info);

            LastAxisPositions = UpdateAxisState(info);
            LastButtonStates = UpdateButtonState(info);
        }

        public void EndCapture()
        {
            LastAxisPositions.Clear();
            LastButtonStates.Clear();
        }

        public List<string> GetPushedButtons()
        {
            List<bool> states = GetButtonStates();
            List<string> buttons = new List<string>();

            if (LastButtonStates.Count != 0 || LastButtonStates.Count != states.Count)
            {
                for (int i = 0; i < states.Count; i++)
                {
                    if (states[i] != LastButtonStates[i])
                        buttons.Add(Buttons[i]);
                }
            }
            LastButtonStates = states;
            return buttons;
        }

        public List<string> GetMovedAxes()
        {
            List<double> states = GetAxisStates();
            List<string> axes = new List<string>();

            if (LastAxisPositions.Count != 0 || LastAxisPositions.Count != states.Count)
            {
                for (int i = 0; i < states.Count; i++)
                {
                    double delta = states[i] - LastAxisPositions[i];
                    if (Math.Abs(delta) > 0.01)
                        axes.Add(Axes[i]);
                }
            }
            LastAxisPositions = states;
            return axes;
        }

        public List<double> GetAxisStates()
        {
            WinMMAPI.JOYINFOEX info = new WinMMAPI.JOYINFOEX();
            info.flags = WinMMAPI.JoyPosFlags.ReturnAll;

            WinMMAPI.joyGetPosEx(ID, info);
            return UpdateAxisState(info);
        }

        public List<bool> GetButtonStates()
        {
            WinMMAPI.JOYINFOEX info = new WinMMAPI.JOYINFOEX();
            info.flags = WinMMAPI.JoyPosFlags.ReturnAll;

            WinMMAPI.joyGetPosEx(ID, info);
            return UpdateButtonState(info);
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

        public static string GetButtonLabel(int index)
        {
            return "Button" + (index + 1).ToString();
        }

        private static Joystick LoadJoystick(int index)
        {
            Joystick stick = new Joystick();
            stick.ID = index;

            stick.Capabilities = new WinMMAPI.JOYCAPS();
            int size = Marshal.SizeOf(stick.Capabilities);

            WinMMAPI.ResultCode result = WinMMAPI.joyGetDevCapsA(index, stick.Capabilities, size);

            if (result != WinMMAPI.ResultCode.NoError || stick.Capabilities.Name == string.Empty)
                return null;

            for (int a = 0; a < stick.Capabilities.axesNumber; a++)
                stick.Axes.Add(GetAxisLabel(a));

            for (int b = 0; b < stick.Capabilities.buttonsNumber; b++)
                stick.Buttons.Add(GetButtonLabel(b));

            return stick;
        }

    }
}
