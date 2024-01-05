namespace LiveCharts2Demo
{
    partial class Form1
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
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            clbOptions = new CheckedListBox();
            lblToggleVisibility = new Label();
            btnViewLogs = new Button();
            SuspendLayout();
            // 
            // cartesianChart1
            // 
            cartesianChart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cartesianChart1.BackColor = SystemColors.Control;
            cartesianChart1.Location = new Point(12, 12);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(653, 500);
            cartesianChart1.TabIndex = 0;
            cartesianChart1.MouseDown += cartesianChart1_Click;
            // 
            // clbOptions
            // 
            clbOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            clbOptions.FormattingEnabled = true;
            clbOptions.Items.AddRange(new object[] { "Unsuccessful Sessions", "Successful Sessions", "Offline", "Diagnostics", "Error" });
            clbOptions.Location = new Point(798, 58);
            clbOptions.Name = "clbOptions";
            clbOptions.Size = new Size(148, 94);
            clbOptions.TabIndex = 1;
            // 
            // lblToggleVisibility
            // 
            lblToggleVisibility.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblToggleVisibility.AutoSize = true;
            lblToggleVisibility.Location = new Point(816, 27);
            lblToggleVisibility.Name = "lblToggleVisibility";
            lblToggleVisibility.Size = new Size(89, 15);
            lblToggleVisibility.TabIndex = 2;
            lblToggleVisibility.Text = "Toggle Visibility";
            // 
            // btnViewLogs
            // 
            btnViewLogs.Location = new Point(894, 504);
            btnViewLogs.Name = "btnViewLogs";
            btnViewLogs.Size = new Size(75, 23);
            btnViewLogs.TabIndex = 3;
            btnViewLogs.Text = "View Logs";
            btnViewLogs.UseVisualStyleBackColor = true;
            btnViewLogs.Click += btnViewLogs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 539);
            Controls.Add(btnViewLogs);
            Controls.Add(lblToggleVisibility);
            Controls.Add(clbOptions);
            Controls.Add(cartesianChart1);
            Name = "Form1";
            Text = "View Logs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private CheckedListBox clbOptions;
        private Label lblToggleVisibility;
        private Button btnViewLogs;
    }
}
