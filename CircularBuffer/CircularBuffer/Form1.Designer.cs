namespace CircularBuffer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCalcAvg = new System.Windows.Forms.Button();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelNumValues = new System.Windows.Forms.Label();
            this.textBoxNumValues = new System.Windows.Forms.TextBox();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCalcAvg
            // 
            this.btnCalcAvg.Location = new System.Drawing.Point(291, 257);
            this.btnCalcAvg.Name = "btnCalcAvg";
            this.btnCalcAvg.Size = new System.Drawing.Size(140, 62);
            this.btnCalcAvg.TabIndex = 0;
            this.btnCalcAvg.Text = "Calculate Average";
            this.btnCalcAvg.UseVisualStyleBackColor = true;
            this.btnCalcAvg.Click += new System.EventHandler(this.btnCalcAvg_Click);
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(261, 346);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(135, 32);
            this.lblAverage.TabIndex = 1;
            this.lblAverage.Text = "Average: ";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(57, 49);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(202, 20);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Enter the size of the buffer:";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(274, 49);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(122, 26);
            this.textBoxSize.TabIndex = 3;
            // 
            // labelNumValues
            // 
            this.labelNumValues.AutoSize = true;
            this.labelNumValues.Location = new System.Drawing.Point(67, 104);
            this.labelNumValues.Name = "labelNumValues";
            this.labelNumValues.Size = new System.Drawing.Size(449, 20);
            this.labelNumValues.TabIndex = 4;
            this.labelNumValues.Text = "Enter the Number of values you want to include in the average:";
            // 
            // textBoxNumValues
            // 
            this.textBoxNumValues.Location = new System.Drawing.Point(538, 104);
            this.textBoxNumValues.Name = "textBoxNumValues";
            this.textBoxNumValues.Size = new System.Drawing.Size(100, 26);
            this.textBoxNumValues.TabIndex = 5;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(274, 167);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(186, 48);
            this.btnPopulate.TabIndex = 6;
            this.btnPopulate.Text = "Start populating buffer";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(510, 167);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(128, 20);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Time since start: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.textBoxNumValues);
            this.Controls.Add(this.labelNumValues);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.btnCalcAvg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcAvg;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label labelNumValues;
        private System.Windows.Forms.TextBox textBoxNumValues;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timerStart;
    }
}

