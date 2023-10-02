namespace assignment_solution
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuggestedTypeLabel = new Label();
            label3 = new Label();
            PreciseCheckBox = new CheckBox();
            IntegralOnlyCheckBox = new CheckBox();
            TextBoxMax = new TextBox();
            TextBoxMin = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            SuggestedTypeLabel.Location = new Point(257, 351);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(215, 37);
            SuggestedTypeLabel.TabIndex = 15;
            SuggestedTypeLabel.Text = "not enough data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(50, 351);
            label3.Name = "label3";
            label3.Size = new Size(211, 37);
            label3.TabIndex = 14;
            label3.Text = "Suggested Type:";
            // 
            // PreciseCheckBox
            // 
            PreciseCheckBox.AutoSize = true;
            PreciseCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            PreciseCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            PreciseCheckBox.Location = new Point(50, 281);
            PreciseCheckBox.Name = "PreciseCheckBox";
            PreciseCheckBox.Size = new Size(234, 41);
            PreciseCheckBox.TabIndex = 13;
            PreciseCheckBox.Text = "Must be precise?";
            PreciseCheckBox.UseVisualStyleBackColor = true;
            PreciseCheckBox.Visible = false;
            PreciseCheckBox.CheckedChanged += PreciseCheckBox_CheckedChanged;
            // 
            // IntegralOnlyCheckBox
            // 
            IntegralOnlyCheckBox.AutoSize = true;
            IntegralOnlyCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckBox.Checked = true;
            IntegralOnlyCheckBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            IntegralOnlyCheckBox.Location = new Point(50, 215);
            IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            IntegralOnlyCheckBox.Size = new Size(201, 41);
            IntegralOnlyCheckBox.TabIndex = 12;
            IntegralOnlyCheckBox.Text = "Integral Only?";
            IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckBox.CheckedChanged += IntegralOnlyCheckBox_CheckedChanged;
            // 
            // TextBoxMax
            // 
            TextBoxMax.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxMax.Location = new Point(201, 144);
            TextBoxMax.Name = "TextBoxMax";
            TextBoxMax.Size = new Size(549, 43);
            TextBoxMax.TabIndex = 11;
            TextBoxMax.TextChanged += TextBox_TextChanged;
            TextBoxMax.KeyPress += TextBox_KeyPress;
            // 
            // TextBoxMin
            // 
            TextBoxMin.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxMin.Location = new Point(201, 63);
            TextBoxMin.Name = "TextBoxMin";
            TextBoxMin.Size = new Size(549, 43);
            TextBoxMin.TabIndex = 10;
            TextBoxMin.TextChanged += TextBox_TextChanged;
            TextBoxMin.KeyPress += TextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(50, 144);
            label2.Name = "label2";
            label2.Size = new Size(145, 37);
            label2.TabIndex = 9;
            label2.Text = "Max Value:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 63);
            label1.Name = "label1";
            label1.Size = new Size(148, 37);
            label1.TabIndex = 8;
            label1.Text = "Min Value: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SuggestedTypeLabel);
            Controls.Add(label3);
            Controls.Add(PreciseCheckBox);
            Controls.Add(IntegralOnlyCheckBox);
            Controls.Add(TextBoxMax);
            Controls.Add(TextBoxMin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SuggestedTypeLabel;
        private Label label3;
        private CheckBox PreciseCheckBox;
        private CheckBox IntegralOnlyCheckBox;
        private TextBox TextBoxMax;
        private TextBox TextBoxMin;
        private Label label2;
        private Label label1;
    }
}