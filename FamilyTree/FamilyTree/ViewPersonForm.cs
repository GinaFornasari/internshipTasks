using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FamilyTree
{
    public partial class ViewPersonForm : Form
    {
        private TextBox textBox1;
        private Button btnFind;
        private Button btnUpdate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxName;
        private TextBox textBoxID;
        private TextBox textBoxGender;
        private TextBox textBoxParents;
        private TextBox textBoxChildren;
        private TextBox textBoxOther;
        private Button btnSave;
        private TextBox textBoxWho;
        public ViewPersonForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxWho = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxGender = new System.Windows.Forms.TextBox();
            this.textBoxParents = new System.Windows.Forms.TextBox();
            this.textBoxChildren = new System.Windows.Forms.TextBox();
            this.textBoxOther = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(88, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 59);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Who are we dealing with? (ID number expected)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWho
            // 
            this.textBoxWho.Location = new System.Drawing.Point(313, 88);
            this.textBoxWho.Name = "textBoxWho";
            this.textBoxWho.Size = new System.Drawing.Size(216, 26);
            this.textBoxWho.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(300, 149);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(133, 38);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Person";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(439, 149);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 38);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Person";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Children:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parents";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Other Relationships: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(247, 226);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(324, 26);
            this.textBoxName.TabIndex = 11;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(247, 264);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(324, 26);
            this.textBoxID.TabIndex = 12;
            // 
            // textBoxGender
            // 
            this.textBoxGender.Enabled = false;
            this.textBoxGender.Location = new System.Drawing.Point(247, 305);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.Size = new System.Drawing.Size(324, 26);
            this.textBoxGender.TabIndex = 13;
            // 
            // textBoxParents
            // 
            this.textBoxParents.Enabled = false;
            this.textBoxParents.Location = new System.Drawing.Point(247, 346);
            this.textBoxParents.Name = "textBoxParents";
            this.textBoxParents.Size = new System.Drawing.Size(324, 26);
            this.textBoxParents.TabIndex = 14;
            // 
            // textBoxChildren
            // 
            this.textBoxChildren.Enabled = false;
            this.textBoxChildren.Location = new System.Drawing.Point(78, 455);
            this.textBoxChildren.Multiline = true;
            this.textBoxChildren.Name = "textBoxChildren";
            this.textBoxChildren.Size = new System.Drawing.Size(285, 148);
            this.textBoxChildren.TabIndex = 15;
            // 
            // textBoxOther
            // 
            this.textBoxOther.Enabled = false;
            this.textBoxOther.Location = new System.Drawing.Point(439, 455);
            this.textBoxOther.Multiline = true;
            this.textBoxOther.Name = "textBoxOther";
            this.textBoxOther.Size = new System.Drawing.Size(292, 148);
            this.textBoxOther.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(656, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 39);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ViewPersonForm
            // 
            this.ClientSize = new System.Drawing.Size(845, 655);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxOther);
            this.Controls.Add(this.textBoxChildren);
            this.Controls.Add(this.textBoxParents);
            this.Controls.Add(this.textBoxGender);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textBoxWho);
            this.Controls.Add(this.textBox1);
            this.Name = "ViewPersonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxWho.Text, out int id))
            {
                if (Manager.Instance.find(id))
                {
                    textBoxName.Text = Manager.Instance.GetPerson(id).name;
                    textBoxID.Text = Manager.Instance.GetPerson(id).id.ToString();
                    textBoxGender.Text = Manager.Instance.GetPerson(id).gender.ToString();
                    textBoxParents.Text = Manager.Instance.GetPerson(id).showParents();
                    textBoxChildren.Text = Manager.Instance.GetPerson(id).showChildren();
                    textBoxOther.Text = Manager.Instance.GetPerson(id).showOthers();
                }
                else
                {
                    MessageBox.Show("Person not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input, please check your ID");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           //yoh too much work nevermind
        }
    }
}
