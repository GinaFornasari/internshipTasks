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
    public partial class FamilyForm : Form
    {
       // Manager manager = Manager.Instance;
        private TextBox textBoxDisplay;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
       // List<Person> persons = new List<Person>();
        //make cooler later
        public FamilyForm()
        {
            InitializeComponent();
            // persons = manager.getFamily();
            DisplayFamily(); 
        }
        private void DisplayFamily()
        {
            Manager.Instance.LoadData();
            List<Person> fam = Manager.Instance.getFamily();
            foreach (Person person in fam)
            {
                textBoxDisplay.Text += person.name + Environment.NewLine; 
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxDisplay = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Location = new System.Drawing.Point(21, 25);
            this.textBoxDisplay.Multiline = true;
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDisplay.Size = new System.Drawing.Size(665, 453);
            this.textBoxDisplay.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FamilyForm
            // 
            this.ClientSize = new System.Drawing.Size(698, 514);
            this.Controls.Add(this.textBoxDisplay);
            this.Name = "FamilyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
