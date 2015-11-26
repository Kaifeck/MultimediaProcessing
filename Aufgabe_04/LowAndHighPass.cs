using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace LowPass
{
    class Program
    {
        static void Main(string[] args)
        {
            Image originalImage = Image.FromFile("castle.bmp");
            Bitmap bit01 = new Bitmap(originalImage);
            Bitmap bitCopy = new Bitmap(bit01.Width, bit01.Height);
            Bitmap bitCopyTwo = new Bitmap(bit01.Width, bit01.Height);
            bitCopy = LowPass(bit01, bitCopy);
            //bitCopyTwo = HighPass(bit01, bitCopyTwo);
            bitCopy.Save("outLow.bmp");
            //bitCopyTwo.Save("outHigh.png");
        }

        static Bitmap LowPass(Bitmap bitOrig, Bitmap bitCopy)
        {
            for (int x = 2; x < bitOrig.Width - 2; x++)
            {
                for (int y = 0; y < bitOrig.Height; y++)
                {
                    byte newRed = GetRed(bitOrig, x, y);
                    byte newBlue = GetBlue(bitOrig, x, y);
                    byte newGreen = GetGreen(bitOrig, x, y);
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    bitCopy.SetPixel(x, y, newColor);

                }
            }
                return bitCopy;
        }

        static Bitmap HighPass(Bitmap bitOrig, Bitmap bitCopy)
        {
            for (int x = 1; x < bitOrig.Width - 1; x++)
            {
                for (int y = 0; y < bitOrig.Height; y++)
                {
                    byte newRed = GetRedHigh(bitOrig, x, y);
                    byte newGreen = GetGreenHigh(bitOrig, x, y);
                    byte newBlue = GetBlueHigh(bitOrig, x, y);
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    bitCopy.SetPixel(x, y, newColor);
                }
            }
            return bitCopy;
        }

        //LOWPASS
        static byte GetRed(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[5];
            array[0] = bitOrig.GetPixel(centerX - 2, centerY).R * (-1.0 / 8.0);
            array[1] = bitOrig.GetPixel(centerX - 1, centerY).R * (2.0 / 8.0);
            array[2] = bitOrig.GetPixel(centerX, centerY).R * (6.0 / 8.0);
            array[3] = bitOrig.GetPixel(centerX + 1, centerY).R * (2.0 / 8.0);
            array[4] = bitOrig.GetPixel(centerX + 2, centerY).R * (-1.0 / 8.0);
            byte red = (byte)(array[0] + array[1] + array[2] + array[3] + array[4]);
            return red;
        }
        static byte GetGreen(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[5];
            array[0] = bitOrig.GetPixel(centerX - 2, centerY).G * (-1.0 / 8.0);
            array[1] = bitOrig.GetPixel(centerX - 1, centerY).G * (2.0 / 8.0);
            array[2] = bitOrig.GetPixel(centerX, centerY).G * (6.0 / 8.0);
            array[3] = bitOrig.GetPixel(centerX + 1, centerY).G * (2.0 / 8.0);
            array[4] = bitOrig.GetPixel(centerX + 2, centerY).G * (-1.0 / 8.0);
            byte green = (byte)(array[0] + array[1] + array[2] + array[3] + array[4]);
            return green;
        }
        static byte GetBlue(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[5];
            array[0] = bitOrig.GetPixel(centerX - 2, centerY).B * (-1.0 / 8.0);
            array[1] = bitOrig.GetPixel(centerX - 1, centerY).B * (2.0 / 8.0);
            array[2] = bitOrig.GetPixel(centerX, centerY).B * (6.0 / 8.0);
            array[3] = bitOrig.GetPixel(centerX + 1, centerY).B * (2.0 / 8.0);
            array[4] = bitOrig.GetPixel(centerX + 2, centerY).B * (-1.0 / 8.0);
            byte blue = (byte)(array[0] + array[1] + array[2] + array[3] + array[4]);
            return blue;
        }

        //HIGHPASS
        static byte GetRedHigh(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[3];
            array[0] = bitOrig.GetPixel(centerX - 1, centerY).R * (-1.0 / 2.0);
            array[1] = bitOrig.GetPixel(centerX, centerY).R;
            array[2] = bitOrig.GetPixel(centerX + 1, centerY).R * (-1.0 / 2.0);
            byte red = (byte)(array[0] + array[1] + array[2]);
            return red;
        }
        static byte GetGreenHigh(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[3];
            array[0] = bitOrig.GetPixel(centerX - 1, centerY).G * (-1.0 / 2.0);
            array[1] = bitOrig.GetPixel(centerX, centerY).G;
            array[2] = bitOrig.GetPixel(centerX + 1, centerY).G * (-1.0 / 2.0);
            byte red = (byte)(array[0] + array[1] + array[2]);
            return red;
        }
        static byte GetBlueHigh(Bitmap bitOrig, int centerX, int centerY)
        {
            double[] array = new double[3];
            array[0] = bitOrig.GetPixel(centerX - 1, centerY).B * (-1.0 / 2.0);
            array[1] = bitOrig.GetPixel(centerX, centerY).B;
            array[2] = bitOrig.GetPixel(centerX + 1, centerY).B * (-1.0 / 2.0);
            byte blue = (byte)(array[0] + array[1] + array[2]);
            return blue;
        }
    }
}
