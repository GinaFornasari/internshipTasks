using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{

    public partial class AddRelationForm: Form
    {
        private ComboBox comboBox1;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private ComboBox comboBox3;
        private Label label3;
        private Label label4;
        private TextBox textBoxID1;
        private TextBox textBoxID2;
        private CheckBox checkBoxOng;
        private Button btnRelationship;

        public AddRelationForm()
        {
            InitializeComponent();
            fillBox1();
            fillBox2();
            checkBoxOng.Checked = true;
        }

        public void fillBox1()
        {
            List<Person> people = Manager.Instance.getFamily(); 
            for(int i = 0; i < people.Count; i++)
            {
                comboBox1.Items.Add(people[i].name);
                comboBox3.Items.Add(people[i].name);
            }

        }
        
        public void fillBox2()
        {
            Relation[] rels = (Relation[])Enum.GetValues(typeof(Relation));

            for(int i=0; i < rels.Length; i++)
            {
                comboBox2.Items.Add(rels[i].ToString());
            }
        }







        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnRelationship = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxID1 = new System.Windows.Forms.TextBox();
            this.textBoxID2 = new System.Windows.Forms.TextBox();
            this.checkBoxOng = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(112, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "is a(n)";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(375, 160);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "to";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(575, 163);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 28);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // btnRelationship
            // 
            this.btnRelationship.Location = new System.Drawing.Point(345, 275);
            this.btnRelationship.Name = "btnRelationship";
            this.btnRelationship.Size = new System.Drawing.Size(151, 58);
            this.btnRelationship.TabIndex = 5;
            this.btnRelationship.Text = "Add Relationship";
            this.btnRelationship.UseVisualStyleBackColor = true;
            this.btnRelationship.Click += new System.EventHandler(this.btnRelationship_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID:";
            // 
            // textBoxID1
            // 
            this.textBoxID1.Location = new System.Drawing.Point(112, 219);
            this.textBoxID1.Name = "textBoxID1";
            this.textBoxID1.Size = new System.Drawing.Size(151, 26);
            this.textBoxID1.TabIndex = 9;
            // 
            // textBoxID2
            // 
            this.textBoxID2.Location = new System.Drawing.Point(575, 222);
            this.textBoxID2.Name = "textBoxID2";
            this.textBoxID2.Size = new System.Drawing.Size(124, 26);
            this.textBoxID2.TabIndex = 10;
            // 
            // checkBoxOng
            // 
            this.checkBoxOng.AutoSize = true;
            this.checkBoxOng.Location = new System.Drawing.Point(360, 224);
            this.checkBoxOng.Name = "checkBoxOng";
            this.checkBoxOng.Size = new System.Drawing.Size(95, 24);
            this.checkBoxOng.TabIndex = 11;
            this.checkBoxOng.Text = "Ongoing\r\n";
            this.checkBoxOng.UseVisualStyleBackColor = true;
            // 
            // AddRelationForm
            // 
            this.ClientSize = new System.Drawing.Size(821, 457);
            this.Controls.Add(this.checkBoxOng);
            this.Controls.Add(this.textBoxID2);
            this.Controls.Add(this.textBoxID1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRelationship);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AddRelationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = comboBox1.SelectedIndex;
            comboBox3.Items.RemoveAt(comboBox1.SelectedIndex);
            textBoxID1.Text = (Manager.Instance.GetPersonByName(comboBox1.SelectedItem.ToString())).id.ToString();
        }

        private void btnRelationship_Click(object sender, EventArgs e)
        {
            Relation[] rels = (Relation[])Enum.GetValues(typeof(Relation));
            if (!int.TryParse(textBoxID1.Text, out int temp) || !int.TryParse(textBoxID2.Text, out int temp2))
            {
                MessageBox.Show("Invalid ID entry");
                return; 
            }
            Person p1 = Manager.Instance.GetPerson(int.Parse(textBoxID1.Text));
            Person p2 = Manager.Instance.GetPerson(int.Parse(textBoxID2.Text));

            //if name and id dont match, error
           /* if(!Manager.Instance.checkValid(comboBox1.SelectedText, int.Parse(textBoxID1.Text)) || !Manager.Instance.checkValid(comboBox3.SelectedText, int.Parse(textBoxID2.Text)))
            {
                MessageBox.Show("Invalid ID-Person pair");
                return;
            }*/

            Relation relate = rels[comboBox2.SelectedIndex]; 
            bool current = checkBoxOng.Checked;

            p1.relationships.Add(new Relationship(p2, relate, current));
            Manager.Instance.writeChanges();

            addOpposite(Manager.Instance.GetPerson(int.Parse(textBoxID1.Text)), Manager.Instance.GetPerson(int.Parse(textBoxID2.Text)), relate, current);
        }

        public void addOpposite(Person p1, Person p2, Relation relate, bool current)
        {
            if (relate.Equals(Relation.AdoptedChild))
            {
                p2.relationships.Add(new Relationship(p1, Relation.AdoptedParent, current));
                Manager.Instance.writeChanges();

            }
            else if (relate.Equals(Relation.AdoptedParent))
            {
                p2.relationships.Add(new Relationship(p1, Relation.AdoptedChild, current));
                Manager.Instance.writeChanges();

            }
            else
            {
                p2.relationships.Add(new Relationship(p1, Relation.Partner, current));
                Manager.Instance.writeChanges();

            }
            Manager.Instance.writeChanges();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxID2.Text = (Manager.Instance.GetPersonByName(comboBox3.SelectedItem.ToString())).id.ToString();
        }
    }
}
