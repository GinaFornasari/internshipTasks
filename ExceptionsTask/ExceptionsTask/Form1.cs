using System.CodeDom;
using System.Diagnostics;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

//internship task
namespace ExceptionsTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Threading.Timer threadingTimer = new System.Threading.Timer(ThreadingTimer_Tick);
            threadingTimer.Change(5000, Timeout.Infinite);


            System.Threading.Timer threadingTimer2 = new System.Threading.Timer(ThreadingTimer_Tick2);
            threadingTimer2.Change(10000, Timeout.Infinite);

        }
        private void ThreadingTimer_Tick(object state)
        {
            calcError();
        }

        private async void ThreadingTimer_Tick2(object state)
        {
            await Task.Run(() =>
            {
                //program closes if exception is thrown instead of messagebox
                MessageBox.Show(new NotImplementedException("Async timer").Message);
            });
        }

        private void GoodBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Good Boy");
        }

        private void BadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 10; int b = 0; int c = a / b;
            }
            catch (DivideByZeroException msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

        private void BadBtn2_Click(object sender, EventArgs e)
        {
            int a = 10; int b = 0;
            try
            {
                int c = a / b;
            }
            catch (DivideByZeroException msg)
            {
                MessageBox.Show(msg.Message);
            }

        }

        private void BadBtn3_Click(object sender, EventArgs e)
        {
            int a = 10; int b = 0;
            try
            {
                int c = a / b;
            }
            catch (IndexOutOfRangeException msg)
            {
                MessageBox.Show(msg.Message);
            }
        }

        private void BadBtn4_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }

        private void BadBtn5_Click(object sender, EventArgs e)
        {
            MessageBox.Show((new Exception("Naughty")).Message);
        }

        private void DareClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show((new IndexOutOfRangeException("Stop it")).Message);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show("timeout");
        }

        private void No_CheckedChanged(object sender, EventArgs e)
        {
            if (No.Checked)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.White;
            }

        }

        private void Yes_CheckedChanged(object sender, EventArgs e)
        {
            doesNothing();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var inp = textBox1.Text;
            try
            {
                int inpInt = int.Parse(inp);
                if (inpInt > 50)
                {
                    MessageBox.Show("TOO BIG");
                }
                else if (inpInt < 0)
                {
                    MessageBox.Show("too small");
                }
                else
                {
                    MessageBox.Show(inp.ToString());
                }
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Nice try");
            }

        }

        private async void ThePoint_Click(object sender, EventArgs e)
        {
            await calcError2();
        }

        private async void AsyncTask_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                throw new Exception("in here");
            });
        }

        //why does it catch?
        private async void AsyncTC_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    throw new Exception("in here");
                });

            }
            catch
            {
                MessageBox.Show("caught");
            }
        }

        //still catches? PLUS terrible (deadlocks)
        private async void AsyncTC2_Click(object sender, EventArgs e)
        {
            try
            {
                var task = Task.Run(() =>
                {
                    throw new Exception("in here");
                });

                // Wait for the task to complete and observe any exceptions
                task.Wait();

                // If you reached this point, the task completed without exceptions
            }
            catch
            {
                MessageBox.Show("caught");
            }
        }


        void doesNothing()
        {
            //doesn't run if after throw
            MessageBox.Show((new Friends("")).Message);
            throw new Friends();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void calcError()
        {
            //calcError2();
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                MessageBox.Show(new IndexOutOfRangeException("CalcErrorCatch").Message);
            }

        }

        async Task calcError2()
        {
            await Task.Run(() =>
            {
                throw new NotImplementedException();
            });

        }

       
    }
}

