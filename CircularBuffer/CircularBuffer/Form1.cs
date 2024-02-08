using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularBuffer
{
    public partial class Form1 : Form
    {
        private BufferManager _bufferManager; 
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxSize.Text, out int capacity))
                {
                    _bufferManager = new BufferManager(capacity);
                    //start populating at random intervals from many threads 
                }
                else
                {
                    MessageBox.Show("please enter a valid buffer Size");
                }
            }
            catch(Exception ex)
            {
                //log
            }
        }

        private void btnCalcAvg_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxSize.Text, out int num))
                {
                    lblAverage.Text = "Average: "+ _bufferManager.GetAverage(num); 
                }
                else
                {
                    MessageBox.Show("please enter a valid average Size");
                }
            }
            catch(Exception ex)
            {
                //log
            }
        }


    }
}
