using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

class picProgram
{
    static void Main(string[] args)
    {
        try
        {
            //Console.WriteLine(args[1]);
            Image imageOne = Image.FromFile(args[1]);
            Bitmap bit01 = new Bitmap(imageOne);
            int low = 75;
            int high = 180;
            //REMOVE BLUE
            for (int x = 0; x < bit01.Width; x++)
            {
                for (int y = 0; y < bit01.Height; y++)
                {
                    //INVERT
                    if (args[0] == "1")
                    {
                        byte newR = (byte)(255.0 - bit01.GetPixel(x,y).R);
                        byte newG = (byte)(255.0 - bit01.GetPixel(x,y).G);
                        byte newB = (byte)(255.0 - bit01.GetPixel(x, y).B);
                        Color invert = Color.FromArgb(newR, newG, newB);
                        bit01.SetPixel(x, y, invert);
                    }
                    else if (args[0] == "2")
                    {//GrayScale
                        //bit01 = clamp(bit01, 75, 180);
                        if (bit01.GetPixel(x, y).R < low)
                        {
                            Color lowColor = Color.FromArgb(low, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                            bit01.SetPixel(x, y, lowColor);
                        }
                        else if (bit01.GetPixel(x, y).R > high)
                        {
                            Color hiColor = Color.FromArgb(high, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                            bit01.SetPixel(x, y, hiColor);
                        }
                    }
                    else if (args[0] == "3")
                    {
                        byte newR = (byte)(bit01.GetPixel(x, y).R * 4);
                        Color multiply = Color.FromArgb(newR, bit01.GetPixel(x,y).G, bit01.GetPixel(x,y).B);
                        bit01.SetPixel(x, y, multiply);
                        if (bit01.GetPixel(x, y).R < 2)
                        {
                            Color lowColor = Color.FromArgb(2, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                            bit01.SetPixel(x, y, lowColor);
                        }
                        else if (bit01.GetPixel(x, y).R > 253)
                        {
                            Color hiColor = Color.FromArgb(253, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                            bit01.SetPixel(x, y, hiColor);
                        }
                    }
                    else if (args[0] == "4")
                    {
                        int intQuantR = bit01.GetPixel(x, y).R / 16;
                        intQuantR = intQuantR * 16;
                        byte tarnsOuant = (byte)intQuantR;
                        Color intQuantColor = Color.FromArgb(intQuantR, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                        bit01.SetPixel(x, y, intQuantColor);
                    }
                    else if (args[0] == "5")
                    {
                        byte newLow = 0;
                        byte newHigh = 255;
                        Color underThreshold = Color.FromArgb(newLow, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                        Color OverThreshold = Color.FromArgb(newHigh, bit01.GetPixel(x, y).G, bit01.GetPixel(x, y).B);
                        if (bit01.GetPixel(x, y).R < 128)
                        {
                            bit01.SetPixel(x, y, underThreshold);
                        }
                        else if (bit01.GetPixel(x, y).R >= 128)
                        {
                            bit01.SetPixel(x, y, OverThreshold);
                        }
                    }
                }
            }
            bit01.Save("out.png");
        }
        catch (Exception e)
        {
            Console.WriteLine("There seems to have been a problem with the program!");
        }
    }
}

