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
    public partial class NewTreeForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        //public static readonly string filePath = "C:\\Users\\ginaf\\source\\repos\\GinaFornasari\\internshipTasks\\FamilyTree\\FamilyTree\\Family.json";
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBoxNm;
        private TextBox textBox4;
        private TextBox textBoxID;
        private Button btnAddP;

        //public static Manager manager = Manager.Instance;
        //public static int numMembers;
        private Button btnDone;
        List<Person> list = new List<Person>();
        public NewTreeForm()
        {
            InitializeComponent();
        }
       

        private void btnAddP_Click(object sender, EventArgs e)
        {
            string name = textBoxNm.Text;
            int id;
            if (int.TryParse(textBoxID.Text, out id))
            {
                Person person = new Person(id, null, null);
                person.name = name;
                list.Add(person);
            }
            else
            {
                MessageBox.Show("Invalid Input, please check your answers");
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Manager.Instance.addOriginals(list);
            Manager.Instance.writeChanges();
            this.Close();
        }





        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxNm = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.btnAddP = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(187, 84);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 96);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Originals are the \"start\" of the tree, they will have no stored parents. \r\n\r\nAdd " +
    "Originals: \r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(73, 240);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(310, 26);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Enter the name:\r\n\r\n";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNm
            // 
            this.textBoxNm.Location = new System.Drawing.Point(413, 240);
            this.textBoxNm.Multiline = true;
            this.textBoxNm.Name = "textBoxNm";
            this.textBoxNm.Size = new System.Drawing.Size(174, 26);
            this.textBoxNm.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(73, 307);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(310, 26);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "Enter the ID:";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(413, 307);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(174, 26);
            this.textBoxID.TabIndex = 3;
            // 
            // btnAddP
            // 
            this.btnAddP.Location = new System.Drawing.Point(162, 369);
            this.btnAddP.Name = "btnAddP";
            this.btnAddP.Size = new System.Drawing.Size(117, 38);
            this.btnAddP.TabIndex = 4;
            this.btnAddP.Text = "Add Person";
            this.btnAddP.UseVisualStyleBackColor = true;
            this.btnAddP.Click += new System.EventHandler(this.btnAddP_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(380, 369);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(117, 38);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // NewTreeForm
            // 
            this.ClientSize = new System.Drawing.Size(656, 441);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnAddP);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxNm);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "NewTreeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  
    }
}
