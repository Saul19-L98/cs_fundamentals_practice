using System.Numerics;

namespace assignment_solution
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreciseCheckBox.Visible = !PreciseCheckBox.Visible;
            RecalculatedSuggestedType();
        }
        private void PreciseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RecalculatedSuggestedType();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            RecalculatedSuggestedType();
            SetColorOfMaxValueTextField();
        }
        private void SetColorOfMaxValueTextField()
        {
            bool isValid = true;
            if (IsInputCompleted())
            {
                var minValue = BigInteger.Parse(TextBoxMin.Text);
                var maxValue = BigInteger.Parse(TextBoxMax.Text);
                if (maxValue < minValue)
                {
                    isValid = false;
                }
            }
            TextBoxMax.BackColor = isValid ? Color.White : Color.IndianRed;
        }

        private bool IsInputCompleted()
        {
            return 
                TextBoxMin.Text.Length > 0 &&
                TextBoxMin.Text != "-" &&
                TextBoxMax.Text.Length > 0 &&
                TextBoxMax.Text != "-";
                
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!IsValidInput(e.KeyChar, textBox))
            {
                e.Handled = true;
            }
        }

        private static bool IsValidInput(char keyChar, TextBox textBox)
        {
            return 
                char.IsControl(keyChar) || 
                char.IsDigit(keyChar) ||
                (keyChar == '-' && textBox.SelectionStart == 0);
        }
        private void RecalculatedSuggestedType()
        {
            if (IsInputCompleted())
            {
                var minValue = BigInteger.Parse(TextBoxMin.Text);
                var maxValue = BigInteger.Parse(TextBoxMax.Text);
                if (maxValue >= minValue)
                {
                    SuggestedTypeLabel.Text = NumericType.GetName(
                        minValue,
                        maxValue,
                        IntegralOnlyCheckBox.Checked,
                        PreciseCheckBox.Checked);
                    return;
                }
            }
            SuggestedTypeLabel.Text = "not enough data";
        }
    }
}