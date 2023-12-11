using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Give an expression");
            string express = Console.ReadLine();

            //handle brackets 
            List<int> pointerOpen = new List<int>(); 

            for (int i = 0; i < express.Length; i++)
            {
                if (express[i].Equals('('))
                {
                    pointerOpen.Add(i);
                }
                if (express[i].Equals(')'))
                {
                    
                    string temp = express.Substring(pointerOpen.Last() + 1, i - pointerOpen.Last() - 1);
                    
                    //send this off as an expression
                    int answer = calculate(temp);
         
                    //replace expression with answer and change i appropriately 
                    express = express.Substring(0, pointerOpen.Last())+ answer + express.Substring(i + 1);
                    i = pointerOpen.Last() - 1;
                    pointerOpen.RemoveAt(pointerOpen.Count - 1); 
                }
            }

            //all bracketed terms gone, calc the leftovers
            Console.WriteLine(calculate(express)); 
            
        }

        public static int calculate(string express)
        {
            char[] delimiterChars = {
                            '*',
                            '/',
                            '+',
                            '-'
                            };
            var numbers = express.Split(delimiterChars).ToList();
            
            if (express.IndexOf('*') != -1 || express.IndexOf('/') != -1)
            {
                numbers = higherOrder(numbers, express);
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
                    int temp = int.Parse(numbers[count]) - int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                }
            }
            return int.Parse(numbers[count]); 
    }

            

        public static List<string> higherOrder(List<string> numbers, string express)
        { 
            int count = 0;
            for (int i=0; i<express.Length; i++)
            {

                if (express[i].Equals('*'))
                {
                    int temp = int.Parse(numbers[count]) * int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                    numbers.RemoveAt(count-1);
                    --count; 
                }
                if (express[i].Equals('/'))
                {
                    int temp = int.Parse(numbers[count]) / int.Parse(numbers[++count]);
                    numbers[count] = "" + temp;
                    numbers.RemoveAt(count - 1);
                    --count;
                }

                if(express[i].Equals('-') || express[i].Equals('+'))
                {
                    count++;
                }
            }
            return numbers; 
        }

        public static string[] ShiftUp(string[] numbers, int index)
        {
            for(int i= index; i<numbers.Length-1; i++) 
            {
                numbers[index] = numbers[index + 1]; 
            }
            return numbers; 
        }

        public static void display(List<string> numbers)
        {
            for(int i=0; i<numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            
        }
    }
}

