using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace FamilyTree
{
    public partial class PersonForm : Form
    {
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBoxName;
        private TextBox textBoxID;
        private TextBox textBoxIDD;
        private TextBox textBoxIDM;
        private Button btnAddPerson;
        private TextBox textBox1;

        public static List<Person> people;

        public PersonForm()
        {

            InitializeComponent();
            people = Manager.Instance.getFamily(); 

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int id;
            int idD;
            int idM;
            if (int.TryParse(textBoxID.Text, out id))
            {
                id = int.Parse(textBoxID.Text);
            }
            else
            {
                MessageBox.Show("Invalid Input, please check your answers");
            }
            if (int.TryParse(textBoxIDD.Text, out idD))
            {
                id = int.Parse(textBoxIDD.Text);
            }
            else
            {
                MessageBox.Show("Invalid Input, please check your answers");
            }
            if (int.TryParse(textBoxIDM.Text, out idM))
            {
                id = int.Parse(textBoxIDM.Text);
            }
            else
            {
                MessageBox.Show("Invalid Input, please check your answers");
            }
            //add person first 

            if (!find(idM))
            {
                DialogResult res = MessageBox.Show("Mother is not found in the tree, would you like to add her?"){
                    if (res == DialogResult.OK)
                    {
                        //clear everything to add mother and do same for dad
                    }
                }
            }
            if (!find(idD))
            {

            }


        }




        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxIDD = new System.Windows.Forms.TextBox();
            this.textBoxIDM = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(104, 71);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Full Name:\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(104, 155);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(230, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "ID Number:";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(104, 229);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(230, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Biological Father\'s ID Number:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(104, 307);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(230, 26);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Biological Mother\'s ID Number:";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(368, 75);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(240, 26);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(368, 155);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(240, 26);
            this.textBoxID.TabIndex = 5;
            // 
            // textBoxIDD
            // 
            this.textBoxIDD.Location = new System.Drawing.Point(368, 229);
            this.textBoxIDD.Multiline = true;
            this.textBoxIDD.Name = "textBoxIDD";
            this.textBoxIDD.Size = new System.Drawing.Size(240, 26);
            this.textBoxIDD.TabIndex = 6;
            // 
            // textBoxIDM
            // 
            this.textBoxIDM.Location = new System.Drawing.Point(368, 307);
            this.textBoxIDM.Multiline = true;
            this.textBoxIDM.Name = "textBoxIDM";
            this.textBoxIDM.Size = new System.Drawing.Size(240, 26);
            this.textBoxIDM.TabIndex = 7;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(301, 383);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(149, 54);
            this.btnAddPerson.TabIndex = 8;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // PersonForm
            // 
            this.ClientSize = new System.Drawing.Size(730, 506);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.textBoxIDM);
            this.Controls.Add(this.textBoxIDD);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "PersonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
