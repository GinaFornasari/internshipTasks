using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
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
        public Timer timer;


        public Form1()
        {
            InitializeComponent();
            
        }

        private async void btnStart_Click_1(object sender, EventArgs e)
        {
            
            //adding for minutes and hours
            int timeHrs = int.Parse(textBoxHrT.Text) * 3600;
            int timeMins = int.Parse(textBoxMinT.Text) * 60;
            int timeSecs = int.Parse(textBoxSecT.Text);
            int total = timeHrs + timeMins + timeSecs;

            int timeHrsOffset = int.Parse(textBoxHrTO.Text) * 3600;
            int timeMinsOffset = int.Parse(textBoxMinTO.Text) * 60;
            int timeSecsOffset = int.Parse(textBoxSecTO.Text);
            int totalOffset = timeHrsOffset + timeMinsOffset + timeSecsOffset;

            this.totalTime = total;
            this.offsetTime = totalOffset;

            if (totalTime < offsetTime)
            {
                MessageBox.Show("Cannot have an offset greater than the total time");
                return;
            }
            btnStart.Enabled = false;
            btnRestart.Enabled = true;
            btnStop.Enabled = true;
            btnPause.Enabled = true;

            timer = new Timer(totalTime, offsetTime, DateTime.Now);
            textBoxCounter.Text = timer.format(total);

            timer.subscribe(clock);

            Task myTask = Task.Run(() => clock.RunClock());

            timer.TimeChange +=
            (sent, s) =>
                {
                    textBoxCounter.Text = s.updatedTimeLeft;
                    if(timer.total == 0)
                    {
                        btnStop_Click(this, e);
                    }
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

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text.Equals("Pause"))
            {
                btnRestart.Enabled = false;
                btnPause.Text = "Resume";
                timer.Paused();
            }

            else
            {
                btnRestart.Enabled = true;
                btnPause.Text = "Pause";
                timer.Resumed(clock, int.Parse(textBoxCounter.Text), DateTime.Now);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnRestart.Enabled = false;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnPause.Text = "Pause";
            timer.Paused();
            textBoxCounter.Text = "0";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnPause.Text = "Pause";
            timer.Paused();
            textBoxCounter.Text = this.totalTime.ToString();
            timer.Resumed(clock, this.totalTime, DateTime.Now);
        }
    }

}
