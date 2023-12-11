namespace CustomTimer
{
    public partial class Form1 : Form
    {
        public int totalTime {  get; set; }
        public int offsetTime { get; set; }

        public Form1()
        {
            InitializeComponent();
            //getStarted();
        }

        
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            this.totalTime= int.Parse(textBoxSecT.Text);
            this.offsetTime = int.Parse(textBoxSecTO.Text);

            Timer timer = new Timer(totalTime, offsetTime);
            Clock clock = new Clock(totalTime, offsetTime);
            timer.subscribe(clock);
            clock.RunClock(); 
        }

    }

}
