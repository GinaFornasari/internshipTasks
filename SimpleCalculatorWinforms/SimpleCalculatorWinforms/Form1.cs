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
                btnSubmit.Enabled = true;
            }
        }
        private void OperationButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                textboxAnswer.AppendText(clickedButton.Text);
                btnPlus.Enabled = false;
                btnDivide.Enabled = false;
                btnMultiply.Enabled = false;
                btnSubmit.Enabled = false;
                btnDecimal.Enabled = true;
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
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            string s = textboxAnswer.Text;
            if (s == String.Empty || !Char.IsDigit(s[s.Length - 1]))
            {
                MessageBox.Show("Please enter a number before the decimal point");
            }
            else
            {
                textboxAnswer.AppendText(",");
                btnDecimal.Enabled = false;
            }
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            textboxAnswer.Text = String.Empty;
            btnPlus.Enabled = false;
            btnDivide.Enabled = false;
            btnMultiply.Enabled = false;
            btnDecimal.Enabled = true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string express = textboxAnswer.Text;
            if (express.Length == 0)
            {
                return; 
            }
            express = express.Replace('x', '*');
            textboxAnswer.Text = (getSolution(express)).ToString();
            if (textboxAnswer.Text.Equals("")) { 
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
                    if ((i >= 1) && (Char.IsDigit(express[i - 1])))
                    {
                        MessageBox.Show("Incorrectly formatted, missing operations");
                        return "";
                    }
                    pointerOpen.Add(i);
                }
                if (express[i].Equals(')'))
                {
                    if (i < express.Length - 1 && Char.IsDigit(express[i + 1]))
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
                        if (temp.Length == 0)
                        {
                            MessageBox.Show("Please enter an expression between the brackets");
                            return "";
                        }
                        //send this off as an expression
                        var ans = calculate(temp);
                        double answer = 0;
                        if (ans.Equals(""))
                        {
                            return "";
                        }
                        else
                        {
                            answer = double.Parse(ans);
                        }
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
            return "";
        }
        public string calculate(string express)
        {
            char[] delimiterChars = {'*','/','+','-'};
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
                    double temp = double.Parse(numbers[count]) + double.Parse(numbers[++count]);
                    numbers[count] = temp.ToString();
                }
                else if (express[i].Equals('-'))
                {
                    double temp = double.Parse(numbers[count]) - double.Parse(numbers[++count]);
                    numbers[count] = temp.ToString();
                }
            }
            return numbers[count];
        }
        public static string checkForNegative(List<string> numbers, string express)
        {
            int count = -1; 
            for (int i = 0; i < express.Length; i++)
            {
                if (!Char.IsDigit(express[i]) && i > 0 && !express[i].Equals('-'))
                {
                    count++;
                }
                if (express[i].Equals('-'))
                {
                    if (i == 0)
                    {
                        double temp = double.Parse(numbers[0]) *-1;
                        numbers[0] = temp.ToString();
                        express = express.Substring(0, i) + express.Substring(i + 1);
                        i = i - 1;
                    }
                    if (i>0 && !Char.IsDigit(express[i - 1]))
                    {
                        if(express[i - 1].Equals('-')){
                            count++;
                            express = express.Substring(0, i-1) + "+"+ express.Substring(i + 2);
                            i = i - 1;
                        }
                        else
                        {
                            double temp = double.Parse(numbers[count]) * -1;
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
                    double temp = double.Parse(numbers[count]) * double.Parse(numbers[++count]);
                    numbers[count] = temp.ToString();
                    numbers.RemoveAt(count - 1);
                    --count;
                }
                if (express[i].Equals('/'))
                {
                    if (double.Parse(numbers[count+1]) == 0){
                        MessageBox.Show("Cannot Divide by zero");
                        return null;
                    }
                    double temp = double.Parse(numbers[count]) / double.Parse(numbers[++count]);
                    numbers[count] = temp.ToString();
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
    }
}
