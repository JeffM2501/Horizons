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
            if (Joystick.GetDevices().Length == 0)
                return;

            AxisNames = Joystick.GetDevices()[0].Axes;
            ButtonNames = Joystick.GetDevices()[0].Buttons;
        }

        private void InputItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StickGetter getter = new StickGetter();
            getter.IsAxis = IsAxis;
            getter.Command = Command;
            if (getter.ShowDialog(this) == DialogResult.Cancel)
                return;

            InputItem.SelectedText = getter.ControlItem;
        }
    }
}
