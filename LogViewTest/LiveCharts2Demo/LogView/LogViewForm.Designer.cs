namespace LiveCharts2Demo.LogView
{
    partial class LogViewForm
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
            btnLoad = new Button();
            textBoxLineNum = new TextBox();
            scintilla = new ScintillaNET.Scintilla();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(17, 20);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(107, 38);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // textBoxLineNum
            // 
            textBoxLineNum.Location = new Point(539, 22);
            textBoxLineNum.Margin = new Padding(4, 5, 4, 5);
            textBoxLineNum.Name = "textBoxLineNum";
            textBoxLineNum.Size = new Size(414, 31);
            textBoxLineNum.TabIndex = 2;
            // 
            // scintilla
            // 
            scintilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scintilla.AutoCMaxHeight = 9;
            scintilla.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            scintilla.CaretForeColor = Color.White;
            scintilla.CaretLineBackColor = Color.White;
            scintilla.CaretLineVisible = true;
            scintilla.LexerName = null;
            scintilla.Location = new Point(17, 70);
            scintilla.Margin = new Padding(36, 42, 36, 42);
            scintilla.Name = "scintilla";
            scintilla.ScrollWidth = 74;
            scintilla.Size = new Size(1107, 354);
            scintilla.TabIndents = true;
            scintilla.TabIndex = 3;
            scintilla.Text = "scintilla1";
            scintilla.UseRightToLeftReadingLayout = false;
            scintilla.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // LogViewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 535);
            Controls.Add(scintilla);
            Controls.Add(textBoxLineNum);
            Controls.Add(btnLoad);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LogViewForm";
            Text = "LogViewForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private TextBox textBoxLineNum;
        private ScintillaNET.Scintilla scintilla;
    }
}