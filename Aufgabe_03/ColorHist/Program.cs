using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int returnedFromDictionary;
                string toFile = "";
                Image imageOne = Image.FromFile(args[0]);
                Bitmap bit01 = new Bitmap(imageOne);
                Bitmap bitCopy = bit01;
                Dictionary<int, int> amountOfColorIntensity = new Dictionary<int, int>();
                //Initialize Dictionary
                for (int i = 0; i <= 256; i++)
                {
                    amountOfColorIntensity.Add(i, 0);
                }
                for (int x = 0; x < bit01.Width; x++)
                {
                    for (int y = 0; y < bit01.Height; y++)
                    {
                        amountOfColorIntensity.TryGetValue(bit01.GetPixel(x, y).R, out returnedFromDictionary);
                        amountOfColorIntensity.Remove(bit01.GetPixel(x, y).R);
                        amountOfColorIntensity.Add(bit01.GetPixel(x, y).R, returnedFromDictionary + 1);
                    }
                }
                //Write to File
                for (int c = 0; c < amountOfColorIntensity.Count() - 1; c++)
                {
                    string currVal = amountOfColorIntensity.TryGetValue(c, out returnedFromDictionary).ToString();
                    toFile += c + ";" + returnedFromDictionary + "\n";
                }
                File.WriteAllText("out.csv", toFile);
            } catch (Exception e)
            {
                Console.WriteLine("There seems to have been a problem executing the code!");
            }
        }
    }
}
