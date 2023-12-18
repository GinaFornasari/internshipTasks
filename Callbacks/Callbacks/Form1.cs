using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using log4net;
using ConcurrentCollections;
using System.Collections.Concurrent;
using Callbacks;

namespace Callbacks
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        public event EventHandler<SimpleMessageArgs> SimpleMessageEvent;
        private ConcurrentDictionary<string, ConcurrentHashSet<Func<SimpleMessageArgs, Task>>> _simpleSubscribers = new ConcurrentDictionary<string, ConcurrentHashSet<Func<SimpleMessageArgs, Task>>>();
        public Form1()
        {
            InitializeComponent();
            try
            {
                System.Threading.Timer threadingTimer = new System.Threading.Timer(ThreadingTimer_Tick, null, 0, 1000);
                log.Info("Starting a threading timer");
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("Trying to start a threading timer"); 
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            log.Info("WinForms application started.");
        }
        private void ThreadingTimer_Tick(object state)
        {
            try
            {
                log.Info("Defining ticks");
                SimpleMessageEvent?.Invoke(this, new SimpleMessageArgs());
                if (DateTime.Now.Second % 2 == 0)
                {
                    PublishMessage("evenSecond", new SimpleMessageArgs { Message = DateTime.Now.ToString("HH:mm:ss") });
                }
                if (DateTime.Now.Second % 2 != 0)
                {
                    PublishMessage("oddSecond", new SimpleMessageArgs { Message = DateTime.Now.ToString("HH:mm:ss") });
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("Tring to define ticks in ThreadingTimer_Tick");
            }
        }
        private void PublishMessage(string topic, SimpleMessageArgs args)
        {
            log.Info("Publishing Messages");
            try
            {
                if (_simpleSubscribers.TryGetValue(topic, out var subscribers))
                {
                    foreach (var subscriberFunc in subscribers)
                    {
                        _ = subscriberFunc.Invoke(args);
                    }
                }
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("Couldn't get value from subscriber to publish message");
            }
        }
        private void TimerTicker(object sender, EventArgs e)
        {
            try
            {
                Action setTextBoxText = () =>
                {
                    txtbxEvents.Text += DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine;
                };
                if (txtbxEvents.InvokeRequired)
                {
                    txtbxEvents.Invoke(setTextBoxText);
                }
                else
                {
                    setTextBoxText();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred in the events timer ticker"); 
            }
        }
        private void AddSubscriber(string topic, Func<SimpleMessageArgs, Task> subscriber)
        {
            try
            {
                _simpleSubscribers.AddOrUpdate(
                    topic,
                    key => new ConcurrentHashSet<Func<SimpleMessageArgs, Task>>(new[] { subscriber }),
                    (key, existingSet) =>
                    {
                        existingSet.Add(subscriber);
                        return existingSet;
                    });
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info($"A problem occurred while trying to add a subscriber to the hash collection of topic {topic}");
            }
        }
        private void removeSubscriber(string topic)
        {
            try
            {
                _simpleSubscribers.TryRemove(topic, out _);
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info($"A problem occurred while trying to remove a subscriber from the hash collection of topic {topic}");
            }
        }
        private void UpdateTextBox(string message, string topic)
        {
            try
            {
                if (topic.Equals("evenSecond"))
                {
                    if (txtbxEvens.InvokeRequired)
                    {
                        txtbxEvens.Invoke(new Action(() => txtbxEvens.Text += message + Environment.NewLine));
                    }
                    else
                    {
                        txtbxEvens.Text += message;
                    }
                }
                else
                {
                    if (txtbxOdds.InvokeRequired)
                    {
                        txtbxOdds.Invoke(new Action(() => txtbxOdds.Text += message + Environment.NewLine));
                    }
                    else
                    {
                        txtbxOdds.Text += message;
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info($"A problem occurred while trying to update the text box of {topic}");
            }
        }
        private void btnSubEvent_Click(object sender, EventArgs e)
        {
            log.Info("Sub1 Clicked");
            try
            {
                SimpleMessageEvent += TimerTicker;
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred while processing the event subscription button");
            }
        }
        private void btnUbsubEvent_Click(object sender, EventArgs e)
        {
            log.Info("UnSub1 Clicked");
            try
            {
                SimpleMessageEvent -= TimerTicker;
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred while processing the event unsubscription button");
            }
        }
        private void btnSubEven_Click(object sender, EventArgs e)
        {
            try
            {
                AddSubscriber("evenSecond", async (args) =>
                {
                    UpdateTextBox(args.Message, "evenSecond");
                });
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred while processing the evens subscription button");
            }
        }
        private void btnUnsubEven_Click(object sender, EventArgs e)
        {
            try
            {
                removeSubscriber("evenSecond");
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred while processing the evens unsubscription button");
            }
        }
        private void btnSubOdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddSubscriber("oddSecond", async (args) =>
                {
                    UpdateTextBox(args.Message, "oddSecond");
                });
            }catch(Exception ex)
            {
                log.Error(ex.ToString());
                log.Info("A problem occurred while processing the odds subscription button");
            }
        }
        private void btnUnsubOdd_Click(object sender, EventArgs e)
        {
            try
            {
                removeSubscriber("oddSecond");
            }catch(Exception Ex)
            {
                log.Error(Ex.ToString());
                log.Info("A problem occurred while processing the odds unsubscription button");
            }
        }
    }
}

