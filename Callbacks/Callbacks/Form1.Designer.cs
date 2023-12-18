namespace Callbacks
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
            this.btnSubEvent = new System.Windows.Forms.Button();
            this.btnUbsubEvent = new System.Windows.Forms.Button();
            this.btnSubEven = new System.Windows.Forms.Button();
            this.btnUnsubEven = new System.Windows.Forms.Button();
            this.btnSubOdd = new System.Windows.Forms.Button();
            this.btnUnsubOdd = new System.Windows.Forms.Button();
            this.txtbxEvents = new System.Windows.Forms.TextBox();
            this.txtbxEvens = new System.Windows.Forms.TextBox();
            this.txtbxOdds = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnSubEvent
            // 
            this.btnSubEvent.Location = new System.Drawing.Point(59, 42);
            this.btnSubEvent.Name = "btnSubEvent";
            this.btnSubEvent.Size = new System.Drawing.Size(105, 40);
            this.btnSubEvent.TabIndex = 0;
            this.btnSubEvent.Text = "Subscribe";
            this.btnSubEvent.UseVisualStyleBackColor = true;
            this.btnSubEvent.Click += new System.EventHandler(this.btnSubEvent_Click);
            // 
            // btnUbsubEvent
            // 
            this.btnUbsubEvent.Location = new System.Drawing.Point(170, 42);
            this.btnUbsubEvent.Name = "btnUbsubEvent";
            this.btnUbsubEvent.Size = new System.Drawing.Size(111, 40);
            this.btnUbsubEvent.TabIndex = 0;
            this.btnUbsubEvent.Text = "Unsubscribe";
            this.btnUbsubEvent.UseVisualStyleBackColor = true;
            this.btnUbsubEvent.Click += new System.EventHandler(this.btnUbsubEvent_Click);
            // 
            // btnSubEven
            // 
            this.btnSubEven.Location = new System.Drawing.Point(331, 42);
            this.btnSubEven.Name = "btnSubEven";
            this.btnSubEven.Size = new System.Drawing.Size(111, 40);
            this.btnSubEven.TabIndex = 0;
            this.btnSubEven.Text = "Subscribe";
            this.btnSubEven.UseVisualStyleBackColor = true;
            this.btnSubEven.Click += new System.EventHandler(this.btnSubEven_Click);
            // 
            // btnUnsubEven
            // 
            this.btnUnsubEven.Location = new System.Drawing.Point(448, 42);
            this.btnUnsubEven.Name = "btnUnsubEven";
            this.btnUnsubEven.Size = new System.Drawing.Size(115, 40);
            this.btnUnsubEven.TabIndex = 0;
            this.btnUnsubEven.Text = "Unsubscribe";
            this.btnUnsubEven.UseVisualStyleBackColor = true;
            this.btnUnsubEven.Click += new System.EventHandler(this.btnUnsubEven_Click);
            // 
            // btnSubOdd
            // 
            this.btnSubOdd.Location = new System.Drawing.Point(614, 42);
            this.btnSubOdd.Name = "btnSubOdd";
            this.btnSubOdd.Size = new System.Drawing.Size(110, 40);
            this.btnSubOdd.TabIndex = 0;
            this.btnSubOdd.Text = "Subscribe";
            this.btnSubOdd.UseVisualStyleBackColor = true;
            this.btnSubOdd.Click += new System.EventHandler(this.btnSubOdd_Click);
            // 
            // btnUnsubOdd
            // 
            this.btnUnsubOdd.Location = new System.Drawing.Point(730, 42);
            this.btnUnsubOdd.Name = "btnUnsubOdd";
            this.btnUnsubOdd.Size = new System.Drawing.Size(118, 40);
            this.btnUnsubOdd.TabIndex = 0;
            this.btnUnsubOdd.Text = "Unsubscribe";
            this.btnUnsubOdd.UseVisualStyleBackColor = true;
            this.btnUnsubOdd.Click += new System.EventHandler(this.btnUnsubOdd_Click);
            // 
            // txtbxEvents
            // 
            this.txtbxEvents.Location = new System.Drawing.Point(71, 110);
            this.txtbxEvents.Multiline = true;
            this.txtbxEvents.Name = "txtbxEvents";
            this.txtbxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxEvents.Size = new System.Drawing.Size(222, 517);
            this.txtbxEvents.TabIndex = 1;
            // 
            // txtbxEvens
            // 
            this.txtbxEvens.Location = new System.Drawing.Point(336, 110);
            this.txtbxEvens.Multiline = true;
            this.txtbxEvens.Name = "txtbxEvens";
            this.txtbxEvens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxEvens.Size = new System.Drawing.Size(222, 517);
            this.txtbxEvens.TabIndex = 1;
            // 
            // txtbxOdds
            // 
            this.txtbxOdds.Location = new System.Drawing.Point(614, 110);
            this.txtbxOdds.Multiline = true;
            this.txtbxOdds.Name = "txtbxOdds";
            this.txtbxOdds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxOdds.Size = new System.Drawing.Size(222, 517);
            this.txtbxOdds.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 653);
            this.Controls.Add(this.txtbxOdds);
            this.Controls.Add(this.txtbxEvens);
            this.Controls.Add(this.txtbxEvents);
            this.Controls.Add(this.btnUnsubOdd);
            this.Controls.Add(this.btnSubOdd);
            this.Controls.Add(this.btnUnsubEven);
            this.Controls.Add(this.btnSubEven);
            this.Controls.Add(this.btnUbsubEvent);
            this.Controls.Add(this.btnSubEvent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubEvent;
        private System.Windows.Forms.Button btnUbsubEvent;
        private System.Windows.Forms.Button btnSubEven;
        private System.Windows.Forms.Button btnUnsubEven;
        private System.Windows.Forms.Button btnSubOdd;
        private System.Windows.Forms.Button btnUnsubOdd;
        private System.Windows.Forms.TextBox txtbxEvents;
        private System.Windows.Forms.TextBox txtbxEvens;
        private System.Windows.Forms.TextBox txtbxOdds;
        private System.Windows.Forms.Timer timer1;
    }
}

