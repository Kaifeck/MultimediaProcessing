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
        try
        {
            //Console.WriteLine(args[1]);
            Image imageOne = Image.FromFile(args[1]);
            Bitmap bit01 = new Bitmap(imageOne);
            //REMOVE BLUE
            for (int x = 0; x < bit01.Width; x++)
            {
                for (int y = 0; y < bit01.Height; y++)
                {
                    if (args[0] == "1")
                    {
                        Color rm = Color.FromArgb(bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).R, 0);
                        bit01.SetPixel(x, y, rm);
                    }
                    else if (args[0] == "2")
                    {//GrayScale
                        byte gray = (byte)(0.299 * bit01.GetPixel(x, y).R + 0.587 * bit01.GetPixel(x, y).G + 0.114 * bit01.GetPixel(x, y).B);
                        Color grayColor = Color.FromArgb(gray, gray, gray);
                        bit01.SetPixel(x, y, grayColor);
                    }
                    else if (args[0] == "3")
                    {
                        Color swapColor = Color.FromArgb(bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).R, bit01.GetPixel(x, y).B);
                        bit01.SetPixel(x, y, swapColor);
                    }
                }
            }
            bit01.Save("out.png");
        } catch (Exception e)
        {
            Console.WriteLine("There seems to have been a problem with the program!");
        }
    }
}

