namespace ExceptionsTask
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
            components = new System.ComponentModel.Container();
            GoodBtn = new Button();
            BadBtn = new Button();
            BadBtn2 = new Button();
            BadBtn3 = new Button();
            BadBtn4 = new Button();
            DontClick = new Button();
            DareClick = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            Submit = new Button();
            No = new CheckBox();
            Yes = new CheckBox();
            FriendsLabel = new Label();
            GoodBtnLabel = new Label();
            ThePoint = new Button();
            AsyncTask = new Button();
            AsyncTC = new Button();
            AsyncTC2 = new Button();
            SuspendLayout();
            // 
            // GoodBtn
            // 
            GoodBtn.AccessibleName = "GoodBtn";
            GoodBtn.Location = new Point(58, 39);
            GoodBtn.Name = "GoodBtn";
            GoodBtn.Size = new Size(112, 34);
            GoodBtn.TabIndex = 0;
            GoodBtn.Text = "GoodBtn";
            GoodBtn.UseVisualStyleBackColor = true;
            GoodBtn.Click += GoodBtn_Click;
            // 
            // BadBtn
            // 
            BadBtn.Location = new Point(58, 104);
            BadBtn.Name = "BadBtn";
            BadBtn.Size = new Size(112, 34);
            BadBtn.TabIndex = 1;
            BadBtn.Text = "BadBtn";
            BadBtn.UseVisualStyleBackColor = true;
            BadBtn.Click += BadBtn_Click;
            // 
            // BadBtn2
            // 
            BadBtn2.Location = new Point(58, 159);
            BadBtn2.Name = "BadBtn2";
            BadBtn2.Size = new Size(112, 34);
            BadBtn2.TabIndex = 2;
            BadBtn2.Text = "BadBtn2";
            BadBtn2.UseVisualStyleBackColor = true;
            BadBtn2.Click += BadBtn2_Click;
            // 
            // BadBtn3
            // 
            BadBtn3.Location = new Point(58, 218);
            BadBtn3.Name = "BadBtn3";
            BadBtn3.Size = new Size(112, 34);
            BadBtn3.TabIndex = 3;
            BadBtn3.Text = "BadBtn3";
            BadBtn3.UseVisualStyleBackColor = true;
            BadBtn3.Click += BadBtn3_Click;
            // 
            // BadBtn4
            // 
            BadBtn4.Location = new Point(58, 272);
            BadBtn4.Name = "BadBtn4";
            BadBtn4.Size = new Size(112, 34);
            BadBtn4.TabIndex = 4;
            BadBtn4.Text = "BadBtn4";
            BadBtn4.UseVisualStyleBackColor = true;
            BadBtn4.Click += BadBtn4_Click;
            // 
            // DontClick
            // 
            DontClick.Location = new Point(58, 323);
            DontClick.Name = "DontClick";
            DontClick.Size = new Size(112, 34);
            DontClick.TabIndex = 5;
            DontClick.Text = "Don't click";
            DontClick.UseVisualStyleBackColor = true;
            DontClick.Click += BadBtn5_Click;
            // 
            // DareClick
            // 
            DareClick.Location = new Point(58, 363);
            DareClick.Name = "DareClick";
            DareClick.Size = new Size(112, 85);
            DareClick.TabIndex = 6;
            DareClick.Text = "Click.. if you dare";
            DareClick.UseVisualStyleBackColor = true;
            DareClick.Click += DareClick_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(532, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Submit
            // 
            Submit.Location = new Point(550, 92);
            Submit.Name = "Submit";
            Submit.Size = new Size(112, 34);
            Submit.TabIndex = 8;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += button1_Click;
            // 
            // No
            // 
            No.AutoSize = true;
            No.Location = new Point(666, 396);
            No.Name = "No";
            No.Size = new Size(62, 29);
            No.TabIndex = 10;
            No.Text = "No";
            No.UseVisualStyleBackColor = true;
            No.CheckedChanged += No_CheckedChanged;
            // 
            // Yes
            // 
            Yes.AutoSize = true;
            Yes.Location = new Point(666, 361);
            Yes.Name = "Yes";
            Yes.Size = new Size(63, 29);
            Yes.TabIndex = 11;
            Yes.Text = "Yes";
            Yes.UseVisualStyleBackColor = true;
            Yes.CheckedChanged += Yes_CheckedChanged;
            // 
            // FriendsLabel
            // 
            FriendsLabel.AutoSize = true;
            FriendsLabel.Location = new Point(666, 323);
            FriendsLabel.Name = "FriendsLabel";
            FriendsLabel.Size = new Size(133, 25);
            FriendsLabel.TabIndex = 12;
            FriendsLabel.Text = "Are we friends?";
            // 
            // GoodBtnLabel
            // 
            GoodBtnLabel.AutoSize = true;
            GoodBtnLabel.Location = new Point(206, 44);
            GoodBtnLabel.Name = "GoodBtnLabel";
            GoodBtnLabel.Size = new Size(0, 25);
            GoodBtnLabel.TabIndex = 13;
            // 
            // ThePoint
            // 
            ThePoint.Location = new Point(347, 175);
            ThePoint.Name = "ThePoint";
            ThePoint.Size = new Size(112, 34);
            ThePoint.TabIndex = 14;
            ThePoint.Text = "ThePoint";
            ThePoint.UseVisualStyleBackColor = true;
            ThePoint.Click += ThePoint_Click;
            // 
            // AsyncTask
            // 
            AsyncTask.Location = new Point(347, 232);
            AsyncTask.Name = "AsyncTask";
            AsyncTask.Size = new Size(112, 34);
            AsyncTask.TabIndex = 15;
            AsyncTask.Text = "AsyncTask";
            AsyncTask.UseVisualStyleBackColor = true;
            AsyncTask.Click += AsyncTask_Click;
            // 
            // AsyncTC
            // 
            AsyncTC.Location = new Point(347, 292);
            AsyncTC.Name = "AsyncTC";
            AsyncTC.Size = new Size(112, 34);
            AsyncTC.TabIndex = 16;
            AsyncTC.Text = "AsyncTC";
            AsyncTC.UseVisualStyleBackColor = true;
            AsyncTC.Click += AsyncTC_Click;
            // 
            // AsyncTC2
            // 
            AsyncTC2.Location = new Point(347, 343);
            AsyncTC2.Name = "AsyncTC2";
            AsyncTC2.Size = new Size(112, 34);
            AsyncTC2.TabIndex = 17;
            AsyncTC2.Text = "AsyncTC2";
            AsyncTC2.UseVisualStyleBackColor = true;
            AsyncTC2.Click += AsyncTC2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 450);
            Controls.Add(AsyncTC2);
            Controls.Add(AsyncTC);
            Controls.Add(AsyncTask);
            Controls.Add(ThePoint);
            Controls.Add(GoodBtnLabel);
            Controls.Add(FriendsLabel);
            Controls.Add(Yes);
            Controls.Add(No);
            Controls.Add(Submit);
            Controls.Add(textBox1);
            Controls.Add(DareClick);
            Controls.Add(DontClick);
            Controls.Add(BadBtn4);
            Controls.Add(BadBtn3);
            Controls.Add(BadBtn2);
            Controls.Add(BadBtn);
            Controls.Add(GoodBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GoodBtn;
        private Button BadBtn;
        private Button BadBtn2;
        private Button BadBtn3;
        private Button BadBtn4;
        private Button DontClick;
        private Button DareClick;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox1;
        private Button Submit;
        private CheckBox No;
        private CheckBox Yes;
        private Label FriendsLabel;
        private Label GoodBtnLabel;
        private Button ThePoint;
        private Button AsyncTask;
        private Button AsyncTC;
        private Button AsyncTC2;
    }
}
