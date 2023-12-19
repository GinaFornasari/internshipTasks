using System.Windows.Forms;

namespace OrderBook
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
            this.txtbxRest = new System.Windows.Forms.TextBox();
            this.btnRest = new System.Windows.Forms.Button();
            this.lblRest = new System.Windows.Forms.Label();
            this.lblSocket = new System.Windows.Forms.Label();
            this.btnSocket = new System.Windows.Forms.Button();
            this.txtbxSocket = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBoxCoin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtbxRest
            // 
            this.txtbxRest.Location = new System.Drawing.Point(62, 129);
            this.txtbxRest.Multiline = true;
            this.txtbxRest.Name = "txtbxRest";
            this.txtbxRest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxRest.Size = new System.Drawing.Size(443, 468);
            this.txtbxRest.TabIndex = 0;
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(231, 61);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(116, 62);
            this.btnRest.TabIndex = 1;
            this.btnRest.Text = "Get OrderBook";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // lblRest
            // 
            this.lblRest.AutoSize = true;
            this.lblRest.Location = new System.Drawing.Point(262, 29);
            this.lblRest.Name = "lblRest";
            this.lblRest.Size = new System.Drawing.Size(52, 20);
            this.lblRest.TabIndex = 2;
            this.lblRest.Text = "REST";
            // 
            // lblSocket
            // 
            this.lblSocket.AutoSize = true;
            this.lblSocket.Location = new System.Drawing.Point(789, 29);
            this.lblSocket.Name = "lblSocket";
            this.lblSocket.Size = new System.Drawing.Size(59, 20);
            this.lblSocket.TabIndex = 3;
            this.lblSocket.Text = "Socket";
            // 
            // btnSocket
            // 
            this.btnSocket.Location = new System.Drawing.Point(768, 61);
            this.btnSocket.Name = "btnSocket";
            this.btnSocket.Size = new System.Drawing.Size(106, 62);
            this.btnSocket.TabIndex = 4;
            this.btnSocket.Text = "Open Socket";
            this.btnSocket.UseVisualStyleBackColor = true;
            this.btnSocket.Click += new System.EventHandler(this.btnSocket_Click);
            // 
            // txtbxSocket
            // 
            this.txtbxSocket.Location = new System.Drawing.Point(592, 129);
            this.txtbxSocket.Multiline = true;
            this.txtbxSocket.Name = "txtbxSocket";
            this.txtbxSocket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxSocket.Size = new System.Drawing.Size(449, 468);
            this.txtbxSocket.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(490, 609);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 50);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBoxCoin
            // 
            this.comboBoxCoin.FormattingEnabled = true;
            this.comboBoxCoin.Items.AddRange(new object[] {
            "XBTUSD",
            "ETHUSD",
            "XBTUSDT",
            "SOLUSD",
            "LINKUSD",
            "XBTZ23",
            "ETHUSDT",
            "BNBUSD",
            "BMEXUSDT"});
            this.comboBoxCoin.Location = new System.Drawing.Point(416, 26);
            this.comboBoxCoin.Name = "comboBoxCoin";
            this.comboBoxCoin.Size = new System.Drawing.Size(285, 28);
            this.comboBoxCoin.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 671);
            this.Controls.Add(this.comboBoxCoin);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtbxSocket);
            this.Controls.Add(this.btnSocket);
            this.Controls.Add(this.lblSocket);
            this.Controls.Add(this.lblRest);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.txtbxRest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxRest;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.Label lblRest;
        private System.Windows.Forms.Label lblSocket;
        private System.Windows.Forms.Button btnSocket;
        private System.Windows.Forms.TextBox txtbxSocket;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox comboBoxCoin;

    }
}

