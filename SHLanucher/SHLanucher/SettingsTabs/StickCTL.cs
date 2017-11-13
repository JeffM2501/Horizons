using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SHLanucher.SettingsTabs
{
    public partial class StickCTL : UserControl
    {

        public static List<string> AxisNames = new List<string>();
        public static List<string> ButtonNames = new List<string>();

        public string Command = string.Empty;
        public string Value { get {return InputItem != null ? InputItem.SelectedText : string.Empty; } }

        public bool IsAxis = false;
        public StickCTL()
        {
            InitializeComponent();
        }

        public StickCTL(string commandName, bool axis, string value)
        {
            InitializeComponent();
            Setup(commandName, axis, value);
        }

        private void CommandLabel_Click(object sender, EventArgs e)
        {

        }

        public void Setup(string commandName, bool axis, string value)
        {
            CommandLabel.Text = commandName;
            IsAxis = axis;

            CheckSticks();

            if (axis)
                InputItem.Items.AddRange(AxisNames.ToArray());
            else
                InputItem.Items.AddRange(ButtonNames.ToArray());

            InputItem.SelectedText = value;
        }

        void CheckSticks()
        {
            if (AxisNames.Count == 0 || ButtonNames.Count == 0)
            {
                LoadSticks();
            }
        }

        public void LoadSticks()
        {
            for(int i = 0; i < WinMMAPI.joyGetNumDevs(); i++)
            {
                WinMMAPI.JOYCAPS caps = new WinMMAPI.JOYCAPS();
                int size = Marshal.SizeOf(caps);

                WinMMAPI.ResultCode result = WinMMAPI.joyGetDevCapsA(i, caps, size);

                if (result == WinMMAPI.ResultCode.NoError && caps.Name != string.Empty)
                {
                    for (int a = 0; a < caps.axesNumber; a++)
                        AxisNames.Add(GetAxisLabel(a));

                    for (int b = 0; b < caps.buttonsNumber; b++)
                        ButtonNames.Add(GetButtonLabel(b));
                }
            }
        }

        public static string GetButtonLabel(int index)
        {
            return "Button" + (index + 1).ToString();
        }

        public static string GetAxisLabel(int index)
        {
            switch(index)
            {
                case 0:
                    return "X";
                case 1:
                    return "Y";
                case 2:
                    return "R";
                case 3:
                    return "Z";
            }

            return "Axis_" + index.ToString();
        }

        public int GetGamePadCount()
        {
            return 0;
//             int count = 0;
//             for (int i = 0; i < 16; i++)
//             {
//                 GamePadCapabilities caps = GamePad.GetCapabilities(i);
//                 if (!caps.IsConnected)
//                     return count;
//                 count++;
// 
//             }
// 
//             return count;
        }

        private void InputItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StickGetter getter = new StickGetter();
            getter.Command = Command;
            if (getter.ShowDialog(this) == DialogResult.Cancel)
                return;

            InputItem.SelectedText = getter.ControlItem;
        }
    }
}
