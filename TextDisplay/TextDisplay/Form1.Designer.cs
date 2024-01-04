namespace TextDisplay
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
            this.scintilla = new ScintillaNET.Scintilla();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLineNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // scintilla
            // 
            this.scintilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla.Location = new System.Drawing.Point(22, 63);
            this.scintilla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scintilla.Name = "scintilla";
            this.scintilla.ReadOnly = true;
            this.scintilla.Size = new System.Drawing.Size(1273, 721);
            this.scintilla.TabIndex = 0;
            this.scintilla.MarginClick += new System.EventHandler<ScintillaNET.MarginClickEventArgs>(this.scintilla_MarginClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // textBoxLineNum
            // 
            this.textBoxLineNum.Location = new System.Drawing.Point(717, 18);
            this.textBoxLineNum.Name = "textBoxLineNum";
            this.textBoxLineNum.Size = new System.Drawing.Size(267, 26);
            this.textBoxLineNum.TabIndex = 3;
            this.textBoxLineNum.TextChanged += new System.EventHandler(this.textBoxLineNum_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 805);
            this.Controls.Add(this.textBoxLineNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scintilla);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla scintilla;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLineNum;
    }
}

