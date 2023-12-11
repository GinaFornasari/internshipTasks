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
            SuspendLayout();
            // 
            // textBoxHrT
            // 
            textBoxHrT.Location = new Point(114, 43);
            textBoxHrT.Name = "textBoxHrT";
            textBoxHrT.Size = new Size(150, 31);
            textBoxHrT.TabIndex = 0;
            // 
            // textBoxMinT
            // 
            textBoxMinT.Location = new Point(348, 43);
            textBoxMinT.Name = "textBoxMinT";
            textBoxMinT.Size = new Size(150, 31);
            textBoxMinT.TabIndex = 1;
            // 
            // textBoxSecT
            // 
            textBoxSecT.Location = new Point(585, 43);
            textBoxSecT.Name = "textBoxSecT";
            textBoxSecT.Size = new Size(150, 31);
            textBoxSecT.TabIndex = 2;
            // 
            // textBoxHrTO
            // 
            textBoxHrTO.Location = new Point(114, 103);
            textBoxHrTO.Name = "textBoxHrTO";
            textBoxHrTO.Size = new Size(150, 31);
            textBoxHrTO.TabIndex = 3;
            // 
            // textBoxMinTO
            // 
            textBoxMinTO.Location = new Point(348, 103);
            textBoxMinTO.Name = "textBoxMinTO";
            textBoxMinTO.Size = new Size(150, 31);
            textBoxMinTO.TabIndex = 4;
            // 
            // textBoxSecTO
            // 
            textBoxSecTO.Location = new Point(585, 103);
            textBoxSecTO.Name = "textBoxSecTO";
            textBoxSecTO.Size = new Size(150, 31);
            textBoxSecTO.TabIndex = 5;
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
            btnStart.Location = new Point(348, 206);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 8;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
