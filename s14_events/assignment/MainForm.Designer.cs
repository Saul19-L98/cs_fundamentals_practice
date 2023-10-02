namespace assignment
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
            label1 = new Label();
            label2 = new Label();
            TextBoxMin = new TextBox();
            TextBoxMax = new TextBox();
            IntegralOnlyCheckBox = new CheckBox();
            PreciseCheckBox = new CheckBox();
            label3 = new Label();
            SuggestedTypeLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(65, 50);
            label1.Name = "label1";
            label1.Size = new Size(148, 37);
            label1.TabIndex = 0;
            label1.Text = "Min Value: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 131);
            label2.Name = "label2";
            label2.Size = new Size(145, 37);
            label2.TabIndex = 1;
            label2.Text = "Max Value:";
            // 
            // TextBoxMin
            // 
            TextBoxMin.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxMin.Location = new Point(216, 50);
            TextBoxMin.Name = "TextBoxMin";
            TextBoxMin.Size = new Size(549, 43);
            TextBoxMin.TabIndex = 2;
            TextBoxMin.TextChanged += TextBoxMin_TextChanged;
            TextBoxMin.KeyPress += TextBoxMin_KeyPress;
            // 
            // TextBoxMax
            // 
            TextBoxMax.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxMax.Location = new Point(216, 131);
            TextBoxMax.Name = "TextBoxMax";
            TextBoxMax.Size = new Size(549, 43);
            TextBoxMax.TabIndex = 3;
            TextBoxMax.TextChanged += TextBoxMax_TextChanged;
            TextBoxMax.KeyPress += TextBoxMax_KeyPress;
            // 
            // IntegralOnlyCheckBox
            // 
            IntegralOnlyCheckBox.AutoSize = true;
            IntegralOnlyCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckBox.Checked = true;
            IntegralOnlyCheckBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            IntegralOnlyCheckBox.Location = new Point(65, 202);
            IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            IntegralOnlyCheckBox.Size = new Size(201, 41);
            IntegralOnlyCheckBox.TabIndex = 4;
            IntegralOnlyCheckBox.Text = "Integral Only?";
            IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // PreciseCheckBox
            // 
            PreciseCheckBox.AutoSize = true;
            PreciseCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            PreciseCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            PreciseCheckBox.Location = new Point(65, 268);
            PreciseCheckBox.Name = "PreciseCheckBox";
            PreciseCheckBox.Size = new Size(234, 41);
            PreciseCheckBox.TabIndex = 5;
            PreciseCheckBox.Text = "Must be precise?";
            PreciseCheckBox.UseVisualStyleBackColor = true;
            PreciseCheckBox.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(65, 338);
            label3.Name = "label3";
            label3.Size = new Size(211, 37);
            label3.TabIndex = 6;
            label3.Text = "Suggested Type:";
            // 
            // SuggestedTypeLabel
            // 
            SuggestedTypeLabel.AutoSize = true;
            SuggestedTypeLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            SuggestedTypeLabel.Location = new Point(272, 338);
            SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            SuggestedTypeLabel.Size = new Size(215, 37);
            SuggestedTypeLabel.TabIndex = 7;
            SuggestedTypeLabel.Text = "not enough data";
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
            Text = "C# numeric type";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TextBoxMin;
        private TextBox TextBoxMax;
        private CheckBox IntegralOnlyCheckBox;
        private CheckBox PreciseCheckBox;
        private Label label3;
        private Label SuggestedTypeLabel;
    }
}