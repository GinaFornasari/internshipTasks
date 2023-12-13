namespace CustomTimer
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
            textBoxHrT = new TextBox();
            textBoxMinT = new TextBox();
            textBoxSecT = new TextBox();
            textBoxHrTO = new TextBox();
            textBoxMinTO = new TextBox();
            textBoxSecTO = new TextBox();
            labelTotal = new Label();
            labelOffset = new Label();
            btnStart = new Button();
            HoursLabel = new Label();
            MinutesLabel = new Label();
            SecondsLabel = new Label();
            textBoxCounter = new TextBox();
            btnPause = new Button();
            btnStop = new Button();
            btnRestart = new Button();
            SuspendLayout();
            // 
            // textBoxHrT
            // 
            textBoxHrT.AcceptsReturn = true;
            textBoxHrT.AcceptsTab = true;
            textBoxHrT.Location = new Point(114, 46);
            textBoxHrT.Name = "textBoxHrT";
            textBoxHrT.PlaceholderText = "0";
            textBoxHrT.Size = new Size(150, 31);
            textBoxHrT.TabIndex = 0;
            textBoxHrT.Text = "0";
            // 
            // textBoxMinT
            // 
            textBoxMinT.Location = new Point(348, 43);
            textBoxMinT.Name = "textBoxMinT";
            textBoxMinT.PlaceholderText = "0";
            textBoxMinT.Size = new Size(150, 31);
            textBoxMinT.TabIndex = 1;
            textBoxMinT.Text = "0";
            // 
            // textBoxSecT
            // 
            textBoxSecT.Location = new Point(585, 43);
            textBoxSecT.Name = "textBoxSecT";
            textBoxSecT.PlaceholderText = "0";
            textBoxSecT.Size = new Size(150, 31);
            textBoxSecT.TabIndex = 2;
            textBoxSecT.Text = "0";
            // 
            // textBoxHrTO
            // 
            textBoxHrTO.Location = new Point(114, 103);
            textBoxHrTO.Name = "textBoxHrTO";
            textBoxHrTO.PlaceholderText = "0";
            textBoxHrTO.Size = new Size(150, 31);
            textBoxHrTO.TabIndex = 3;
            textBoxHrTO.Text = "0";
            // 
            // textBoxMinTO
            // 
            textBoxMinTO.Location = new Point(348, 103);
            textBoxMinTO.Name = "textBoxMinTO";
            textBoxMinTO.PlaceholderText = "0";
            textBoxMinTO.Size = new Size(150, 31);
            textBoxMinTO.TabIndex = 4;
            textBoxMinTO.Text = "0";
            // 
            // textBoxSecTO
            // 
            textBoxSecTO.Location = new Point(585, 103);
            textBoxSecTO.Name = "textBoxSecTO";
            textBoxSecTO.PlaceholderText = "0";
            textBoxSecTO.Size = new Size(150, 31);
            textBoxSecTO.TabIndex = 5;
            textBoxSecTO.Text = "0";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(25, 49);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(49, 25);
            labelTotal.TabIndex = 6;
            labelTotal.Text = "Total";
            // 
            // labelOffset
            // 
            labelOffset.AutoSize = true;
            labelOffset.Location = new Point(25, 106);
            labelOffset.Name = "labelOffset";
            labelOffset.Size = new Size(61, 25);
            labelOffset.TabIndex = 7;
            labelOffset.Text = "Offset";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(348, 187);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 8;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // HoursLabel
            // 
            HoursLabel.AutoSize = true;
            HoursLabel.Location = new Point(155, 12);
            HoursLabel.Name = "HoursLabel";
            HoursLabel.Size = new Size(60, 25);
            HoursLabel.TabIndex = 9;
            HoursLabel.Text = "Hours";
            HoursLabel.Click += label1_Click;
            // 
            // MinutesLabel
            // 
            MinutesLabel.AutoSize = true;
            MinutesLabel.Location = new Point(385, 12);
            MinutesLabel.Name = "MinutesLabel";
            MinutesLabel.Size = new Size(75, 25);
            MinutesLabel.TabIndex = 10;
            MinutesLabel.Text = "Minutes";
            // 
            // SecondsLabel
            // 
            SecondsLabel.AutoSize = true;
            SecondsLabel.Location = new Point(620, 15);
            SecondsLabel.Name = "SecondsLabel";
            SecondsLabel.Size = new Size(79, 25);
            SecondsLabel.TabIndex = 11;
            SecondsLabel.Text = "Seconds";
            SecondsLabel.Click += label3_Click;
            // 
            // textBoxCounter
            // 
            textBoxCounter.AcceptsReturn = true;
            textBoxCounter.Location = new Point(92, 279);
            textBoxCounter.Multiline = true;
            textBoxCounter.Name = "textBoxCounter";
            textBoxCounter.ReadOnly = true;
            textBoxCounter.Size = new Size(301, 103);
            textBoxCounter.TabIndex = 12;
            textBoxCounter.TextChanged += textBoxCounter_TextChanged;
            // 
            // btnPause
            // 
            btnPause.Enabled = false;
            btnPause.Location = new Point(516, 317);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(112, 34);
            btnPause.TabIndex = 13;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(516, 357);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 34);
            btnStop.TabIndex = 14;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnRestart
            // 
            btnRestart.Enabled = false;
            btnRestart.Location = new Point(516, 277);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(112, 34);
            btnRestart.TabIndex = 15;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRestart);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(textBoxCounter);
            Controls.Add(SecondsLabel);
            Controls.Add(MinutesLabel);
            Controls.Add(HoursLabel);
            Controls.Add(btnStart);
            Controls.Add(labelOffset);
            Controls.Add(labelTotal);
            Controls.Add(textBoxSecTO);
            Controls.Add(textBoxMinTO);
            Controls.Add(textBoxHrTO);
            Controls.Add(textBoxSecT);
            Controls.Add(textBoxMinT);
            Controls.Add(textBoxHrT);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxHrT;
        private TextBox textBoxMinT;
        private TextBox textBoxSecT;
        private TextBox textBoxHrTO;
        private TextBox textBoxMinTO;
        private TextBox textBoxSecTO;
        private Label labelTotal;
        private Label labelOffset;
        private Button btnStart;
        private Label HoursLabel;
        private Label MinutesLabel;
        private Label SecondsLabel;
        private TextBox textBoxCounter;
        private Button btnPause;
        private Button btnStop;
        private Button btnRestart;
    }
}
