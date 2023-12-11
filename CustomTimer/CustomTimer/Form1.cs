namespace CustomTimer
{
    public partial class Form1 : Form
    {
        public int totalTime { get; set; }
        public int offsetTime { get; set; }
        public Clock clock = new Clock();
        Timer timer;

        //public delegate void updateDisplay(object clock, TimeEventArgs timeinfo);
        //public TimeChangedHandler TimeChanged;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            this.totalTime = int.Parse(textBoxSecT.Text);
            this.offsetTime = int.Parse(textBoxSecTO.Text);
            timer = new Timer(totalTime, offsetTime, DateTime.Now.Second);
            timer.subscribe(clock);
            clock.RunClock();
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

        public void updateTextBox(string text)
        {
            textBoxCounter.Text = text;
        }

        /*public string getNewTime()
        {
            
        }*/
    }

}
