using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bitte geben sie ihre zahl, die urprüngliche Basis und zuletzt die gewünschte basis ein!");
                Console.Write("Die Zahl in Mathematischer Schreibweise: ");
                string origNum = Console.ReadLine();
                string[] splitted = origNum.Split(',');
                Console.Write("Die Basis der Zahl: ");
                int origBaseMain = int.Parse(Console.ReadLine());
                Console.Write("Die gewünschte Basis: ");
                int tgtBaseMain = int.Parse(Console.ReadLine());
                string returnedFromBaseConverter = baseConverter(splitted, origBaseMain, tgtBaseMain);
                Console.WriteLine(returnedFromBaseConverter);
                Console.ReadLine();
            } catch (Exception e)
            {
                Console.WriteLine("Caught an Exception!");
                Console.ReadLine();
            }
        }

        static string baseConverter(string[] origNumber, int origBase, int tgtBase)
        {
            int decimalNumber = 0;
            double[] outArr = new double[origNumber.Length];
            string convertedNumberNewBaseReturn = "";
            string flippedReturn = "";
            //origBase^pos*regNumber[pos]
            for (int i = 0; i < origNumber.Length; i++)
            {
                outArr[i] = double.Parse(origNumber[origNumber.Length - i - 1]);
                if (outArr[i] > origBase-1)
                {
                    throw new System.ArgumentException("Entered Number is not coded in Base!");
                }
                decimalNumber += (int)Math.Pow(origBase, i) * (int)outArr[i];
            }
            while (decimalNumber != 0)
            {
                convertedNumberNewBaseReturn += (decimalNumber % tgtBase).ToString() + ',';
                decimalNumber /= tgtBase;
            }
            convertedNumberNewBaseReturn = convertedNumberNewBaseReturn.TrimEnd(',');
            for (int j = 0; j < convertedNumberNewBaseReturn.Length; j++)
            {
                flippedReturn += convertedNumberNewBaseReturn.Substring(convertedNumberNewBaseReturn.Length - j - 1, 1);
            }
            return flippedReturn;
        }
    }
}
