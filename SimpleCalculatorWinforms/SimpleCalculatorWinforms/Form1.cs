using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculatorWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //btnMinus.Enabled = false;
            btnPlus.Enabled = false;
            btnDivide.Enabled = false;
            btnMultiply.Enabled = false;

            btn1.Click += CommonButtonClick;
            btn2.Click += CommonButtonClick;
            btn3.Click += CommonButtonClick;
            btn4.Click += CommonButtonClick;
            btn5.Click += CommonButtonClick;
            btn6.Click += CommonButtonClick;
            btn7.Click += CommonButtonClick;
            btn8.Click += CommonButtonClick;
            btn9.Click += CommonButtonClick;
            btn0.Click += CommonButtonClick;
            btnMinus.Click += OperationButtonClick;
            btnMultiply.Click += OperationButtonClick;
            btnDivide.Click += OperationButtonClick;
            btnPlus.Click += OperationButtonClick;
            btnOpenB.Click += BracketButtonClick;
            btnCloseB.Click += BracketButtonClick;

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }
        

        private void CommonButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
          
            if (clickedButton != null)
            {
                textboxAnswer.AppendText(clickedButton.Text);
                btnMinus.Enabled = true;
                btnPlus.Enabled = true;
                btnDivide.Enabled = true;
                btnMultiply.Enabled = true;
            }
        }
        private void OperationButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                textboxAnswer.AppendText(clickedButton.Text);
                //btnMinus.Enabled = false;
                btnPlus.Enabled = false;
                btnDivide.Enabled = false;
                btnMultiply.Enabled = false;
            }
        }

        private void BracketButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                textboxAnswer.AppendText(clickedButton.Text);
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string express = textboxAnswer.Text;
            express = express.Replace('x', '*');
            textboxAnswer.Text = (getSolution(express)).ToString();
            if (textboxAnswer.Text.Equals("")){
                //btnMinus.Enabled = false;
                btnPlus.Enabled = false;
                btnDivide.Enabled = false;
                btnMultiply.Enabled = false;
            }
        }
        public string getSolution(string express)
        {
            //handle brackets 
            List<int> pointerOpen = new List<int>();

            for (int i = 0; i < express.Length; i++)
            { 
                if (express[i].Equals('('))
                {
                    if ((i >= 1) && (Char.IsDigit(express[i-1])))
                    {
                        MessageBox.Show("Incorrectly formatted, missing operations");
                        return "";
                    }
                    pointerOpen.Add(i);
                }
                if (express[i].Equals(')'))
                {
                    if (i < express.Length - 1 && Char.IsDigit(express[i+1]))
                    {
                        MessageBox.Show("Incorrectly formatted, missing operations");
                        return "";
                    }
                    if (pointerOpen.Count() == 0)
                    {
                        MessageBox.Show("Incorrectly formatted, missing brackets");
                        return "";
                    }
                    else
                    {
                        string temp = express.Substring(pointerOpen.Last() + 1, i - pointerOpen.Last() - 1);

                        //send this off as an expression
                        
                        var ans = calculate(temp);
                        int answer = 0; 
                        if (ans.Equals(""))
                        {
                            return ""; 
                        }
                        else
                        {
                            answer = int.Parse(ans); 
                        }

                        //replace expression with answer and change i appropriately 
                        express = express.Substring(0, pointerOpen.Last()) + answer + express.Substring(i + 1);
                        i = pointerOpen.Last() - 1;
                        pointerOpen.RemoveAt(pointerOpen.Count - 1);
                    }
                }
            }
            if (pointerOpen.Count() != 0)
            {
                MessageBox.Show("Incorrectly formatted, missing brackets");
            }
            else
            {
                return (calculate(express).ToString());
            }
            //all bracketed terms gone, calc the leftovers

            return ""; 

        }
     

        public string calculate(string express)
        {
            char[] delimiterChars = {
                            '*',
                            '/',
                            '+',
                            '-'
                            };
            var numbers = express.Split(delimiterChars).ToList();
            numbers.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            express = checkForNegative(numbers, express);

            if (express.IndexOf('*') != -1 || express.IndexOf('/') != -1)
            {
                numbers = higherOrder(numbers, express);
            }

            if (numbers == null)
            {
                return ""; 
            }

            int count = 0;
            for (int i = 0; i < express.Length; i++)
            {
                if (express[i].Equals('+'))
                {
                    int temp = int.Parse(numbers[count]) + int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                }
                else if (express[i].Equals('-'))
                {
                    int temp;
                    //on minus: previous can be an operation, following has to be a number
                    if (!int.TryParse(numbers[count], out temp))
                    {
                        //if the previous is not a number
                        MessageBox.Show("made it this far"); 

                    }

                    temp = int.Parse(numbers[count]) - int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                }
            }
            return numbers[count];
        }
         public static string Show(List<string> nums)
         {
             string str = "";
            for(int i=0; i<nums.Count; i++)
            {
                str += nums[i] + "("+ i+")";
            }
             
             return str;
         }
        public static string checkForNegative(List<string> numbers, string express)
        {
            //MessageBox.Show(Show(numbers));
            int count = 0; 
            for (int i = 0; i < express.Length; i++)
            {
                if (Char.IsDigit(express[i]))
                {
                    count++;
                }

                if (express[i].Equals('-'))
                {
                    if (i == 0)
                    {
                        int temp = int.Parse(numbers[0]) *-1;
                        numbers[0] = temp.ToString();
                        express = express.Substring(0, i) + express.Substring(i + 1);
                        i = i - 1;
                       // MessageBox.Show("new " + express); 

                    }
                    if (i>0 && !Char.IsDigit(express[i - 1]))
                    {
                        if(express[i - 1].Equals("-")){
                            MessageBox.Show("double minus");
                            express = express.Substring(0, i-1) + "+"+ express.Substring(i + 2);
                            i = i - 1;
                        }
                        else
                        {
                            int temp = int.Parse(numbers[count]) * -1;
                            numbers[count] = temp.ToString();
                            express = express.Substring(0, i) + express.Substring(i + 1);
                            i = i - 1;
                        }
                        
                    }
                }
            }
            return express; 
        }

        public static List<string> higherOrder(List<string> numbers, string express)
        {
            int count = 0;
            for (int i = 0; i < express.Length; i++)
            {

                if (express[i].Equals('*'))
                {
                    int temp = int.Parse(numbers[count]) * int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                    numbers.RemoveAt(count - 1);
                    --count;
                }
                if (express[i].Equals('/'))
                {
                    if (int.Parse(numbers[count+1]) == 0){
                        MessageBox.Show("Cannot Divide by zero");
                        return null;
                    }
                    int temp = int.Parse(numbers[count]) / int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                    numbers.RemoveAt(count - 1);
                    --count;
                }

                if (express[i].Equals('-') || express[i].Equals('+'))
                {
                    count++;
                }
            }
            return numbers;
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            textboxAnswer.Text = String.Empty;
           // btnMinus.Enabled = false;
            btnPlus.Enabled = false;
            btnDivide.Enabled = false;
            btnMultiply.Enabled = false;
        }
    }
}
