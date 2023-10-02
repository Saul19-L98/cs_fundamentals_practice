namespace windowsDestopApp_example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            IncreaseCounterButton = new Button();
            CounterLabel = new Label();
            SuspendLayout();
            // 
            // IncreaseCounterButton
            // 
            resources.ApplyResources(IncreaseCounterButton, "IncreaseCounterButton");
            IncreaseCounterButton.Name = "IncreaseCounterButton";
            IncreaseCounterButton.UseVisualStyleBackColor = true;
            IncreaseCounterButton.Click += IncreaseCounterButton_Click;
            // 
            // CounterLabel
            // 
            resources.ApplyResources(CounterLabel, "CounterLabel");
            CounterLabel.Name = "CounterLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CounterLabel);
            Controls.Add(IncreaseCounterButton);
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button IncreaseCounterButton;
        private Label CounterLabel;
    }
}