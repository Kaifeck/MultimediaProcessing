using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

class GenerateHuffmanCode
{
    static void Main(string[] args)
    {
        Image imageOne = Image.FromFile("01.bmp");
        Image imageTwo = Image.FromFile("02.bmp");
        Bitmap bit01 = new Bitmap(imageOne);
        Bitmap bit02 = new Bitmap(imageTwo);
        double tmp = 0;
        //MSE Formula
        //(PIXEL 01 - PIXEL 02) ^2
        //sqrt((1/breite*höhe)*raus)
        for (int x = 0; x < bit01.Width; x++)
        {
            for (int y = 0; y < bit01.Height; y++)
            {
                byte gray01 = (byte)(0.299 * bit01.GetPixel(x,y).R + 0.587 * bit01.GetPixel(x,y).G + 0.114 * bit01.GetPixel(x,y).B);
                byte gray02 = (byte)(0.299 * bit02.GetPixel(x, y).R + 0.587 * bit02.GetPixel(x, y).G + 0.114 * bit02.GetPixel(x, y).B);
                tmp += Math.Pow(gray01 - gray02, 2);
            }
        }
        tmp = Math.Sqrt((1 / (double)bit01.Width * (double)bit01.Height) * (double)tmp);
        Console.WriteLine("MSE: " + tmp);
        Console.ReadLine();
    }
}

