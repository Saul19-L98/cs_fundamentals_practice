using System.Diagnostics.Metrics;

namespace assignment
{
    public partial class MainForm : Form
    {
        private nint _minValue;
        private nint _maxValue;
        private bool IntegralOnlyCheckBoxIsChecked => IntegralOnlyCheckBox.Checked;
        public MainForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PreciseCheckBox.Visible = !PreciseCheckBox.Visible;
            UiDisplayingType();
        }

        private void TextBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidMin(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TextBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidMax(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool IsValidMin(char keyChar)
        {
            return char.IsControl(keyChar) || (char.IsDigit(keyChar) || keyChar == '-');
        }
        private bool IsValidMax(char keyChar)
        {
            return char.IsControl(keyChar) || (char.IsDigit(keyChar));
        }
        private void TextBoxMin_TextChanged(object sender, EventArgs e)
        {
            if (nint.TryParse(TextBoxMin.Text, out nint minValue))
            {
                _minValue = minValue;
            }
            UiDisplayingType();
        }

        private void TextBoxMax_TextChanged(object sender, EventArgs e)
        {
            if (nint.TryParse(TextBoxMax.Text, out nint maxValue))
            {
                _maxValue = maxValue;
            }
            UiDisplayingType();
        }
        private void UiDisplayingType()
        {
            SuggestedTypeLabel.Text = IntegralOnlyCheckBoxIsChecked ? SuggestedTypeForIntregers() : SuggestedTypeForDecimals();
        }
        private string SuggestedTypeForIntregers()
        {
            if (_minValue == 0.5 || _maxValue == 0.5)
            {
                return "not enough data";
            }

            if (sbyte.MaxValue <= _minValue && sbyte.MaxValue >= _maxValue)
            {
                return "sbyte";
            }
            else if (_minValue >= byte.MinValue && byte.MaxValue >= _maxValue)
            {
                return "byte";
            }
            else if (short.MinValue <= _minValue && short.MaxValue >= _maxValue)
            {
                return "short";
            }
            else if (_minValue >= ushort.MinValue && ushort.MaxValue >= _maxValue)
            {
                return "ushort";
            }
            else if (int.MinValue <= _minValue && int.MaxValue >= _maxValue)
            {
                return "int";
            }
            else if (_minValue >= uint.MinValue && uint.MaxValue >= _maxValue)
            {
                return "uint";
            }
            else if (long.MinValue <= _minValue && long.MaxValue >= _maxValue)
            {
                return "long";
            }
            else if (_minValue >= 0 && _maxValue > long.MaxValue)
            {
                return "ulong";
            }
            else
            {
                return "impossible to know";
            }
        }
        private string SuggestedTypeForDecimals()
        {
            if (_minValue == 0 || _maxValue == 0)
            {
                return "not enough data";
            }

            if (_minValue >= float.MinValue && _maxValue <= float.MaxValue)
            {
                return "float";
            }
            else
            {
                return "double";
            }
        }
    }
}