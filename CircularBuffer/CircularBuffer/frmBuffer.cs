using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularBuffer
{
    public partial class frmBuffer : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmBuffer));
        private BufferManager _bufferManager;
        private Stopwatch stopwatch;
        private bool running; 
        public frmBuffer()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            running = true; 
            log.Info("Starting Buffer"); 
        }
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxSize.Text, out int capacity))
                {
                    log.Info("populating...");
                    _bufferManager = new BufferManager(capacity);
                    Random random = new Random();
                    NumberGenerator gen1 = new NumberGenerator();
                    NumberGenerator gen2 = new NumberGenerator();
                    NumberGenerator gen3 = new NumberGenerator();
                    Task.Run(async() => 
                    {
                        while (running)
                        {
                            await _bufferManager.AddOrOverride(gen1.GenerateRandomNumber());
                        }
                    });
                    Task.Run(async() =>
                    {
                        while (running)
                        {
                            await _bufferManager.AddOrOverride(gen2.GenerateRandomNumber());
                        }
                    });
                    Task.Run(async() =>
                    {
                        while (running)
                        {
                            await _bufferManager.AddOrOverride(gen3.GenerateRandomNumber());
                        }
                    });
                }
                else
                {
                    MessageBox.Show("please enter a valid buffer Size");
                }
            }
            catch(Exception ex)
            {
                log.Error("Could not Populate buffer"); 
            }
        }
        private void btnCalcAvg_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxNumValues.Text, out int num))
                {
                    Action setAverage = async () =>
                    {
                        stopwatch.Start();
                        double ans = await _bufferManager.GetAverage(num);
                        stopwatch.Stop();
                        lblAverage.Text = "Average " + ans;
                        double time = stopwatch.Elapsed.TotalMilliseconds; 
                        UpdateTimer(time);
                        stopwatch.Reset();
                    };
                    if (lblAverage.InvokeRequired)
                    {
                        lblAverage.Invoke(setAverage);
                    }
                    else
                    {
                        setAverage();
                    }
                }
                else
                {
                    MessageBox.Show("please enter a valid average Size");
                }
                log.Info("Calculated average");
            }
            catch(Exception ex)
            {
                log.Error("Could not calculate average");
            }
        }
        private void UpdateTimer(double time)
        {
            lblTimer.Text = "Time waited: " + stopwatch.Elapsed.TotalMilliseconds;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            running = false; 
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            running = false;
            textBoxNumValues.Text = string.Empty;
            textBoxSize.Text = string.Empty;
        }
    }
}
