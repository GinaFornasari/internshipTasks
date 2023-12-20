namespace FamilyTree
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewPerson = new System.Windows.Forms.Button();
            this.btnRelationship = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(470, 122);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(156, 76);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Family";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(331, 247);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(156, 76);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "See Family";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(615, 248);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 76);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add a Member";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnViewPerson
            // 
            this.btnViewPerson.Location = new System.Drawing.Point(183, 360);
            this.btnViewPerson.Name = "btnViewPerson";
            this.btnViewPerson.Size = new System.Drawing.Size(156, 76);
            this.btnViewPerson.TabIndex = 3;
            this.btnViewPerson.Text = "View Person";
            this.btnViewPerson.UseVisualStyleBackColor = true;
            // 
            // btnRelationship
            // 
            this.btnRelationship.Location = new System.Drawing.Point(798, 360);
            this.btnRelationship.Name = "btnRelationship";
            this.btnRelationship.Size = new System.Drawing.Size(156, 76);
            this.btnRelationship.TabIndex = 4;
            this.btnRelationship.Text = "Add a Relationship";
            this.btnRelationship.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 668);
            this.Controls.Add(this.btnRelationship);
            this.Controls.Add(this.btnViewPerson);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnNew);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnViewPerson;
        private System.Windows.Forms.Button btnRelationship;
    }
}

