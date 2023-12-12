using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public partial class Form1 : Form
    {
        public int totalTime { get; set; }
        public int offsetTime { get; set; }
        Clock clock = new Clock();


        public Form1()
        {
            InitializeComponent();
        }
         

        private async void btnStart_Click_1(object sender, EventArgs e)
        {
            //textBoxCounter.Text = "Starting";
            string totalT = textBoxSecT.Text;
            textBoxCounter.Text = totalT;
            this.totalTime = int.Parse(textBoxSecT.Text);
            this.offsetTime = int.Parse(textBoxSecTO.Text);
           // Clock clock = new Clock();
            Timer timer = new Timer(totalTime, offsetTime, DateTime.Now.Second);
            timer.subscribe(clock);

             Task myTask = Task.Run(() => clock.RunClock());
           // await Task.Run(() => clock.RunClock());


            // theClock.TimeChanged += delegate (object sender, TimeEventArgs e);
            //timer.TimeChange += delegate (string str) { };

            //timer.TimeChange += updateTextBox;

            timer.TimeChange +=
            (sent, s) =>
                {
                    textBoxCounter.Text = s.updatedTimeLeft;
                }; 

            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCounter_TextChanged(object sender, EventArgs e)
        {

        }

        public void updateTextBox(object sender, EventArgs e)
        {
            //textBoxCounter.Text = text;
        }
    }

}
