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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewTreeForm secondForm = new NewTreeForm(); 
            secondForm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //manager.PrintFamilyTree();
            FamilyForm secondForm = new FamilyForm();
            secondForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PersonForm secondForm = new PersonForm();
            secondForm.Show();
        }
    }
}
