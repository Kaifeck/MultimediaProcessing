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
            Image originalImage = Image.FromFile("lena.bmp");
            Bitmap bit01 = new Bitmap(originalImage);
            Bitmap bitCopy = new Bitmap(bit01.Width, bit01.Height);
            Bitmap bitcopy2 = new Bitmap(bit01.Width, bit01.Height);
            int[,] matrix = new int[3, 3] {
                                {1,1,1},
                                {1,2,1},
                                {1,1,1}
                            };
            int[,] matrix2 = new int[3, 3] {
                                {1,1,1},
                                {1,2,1},
                                {1,1,1}
                            };
            int[,] matrix3 = new int[3, 3] {
                                {1,1,1},
                                {1,2,1},
                                {1,1,1}
                            };
            int[,] matrix4 = new int[3, 3] {
                                {1,1,1},
                                {1,2,1},
                                {1,1,1}
                            };
            Bitmap[] bitArray = dilute(bit01, bitCopy, bitcopy2, matrix);
            //Bitmap bitErode = dilute(bit01, bitCopy, bitcopy2);
            //bitErode.Save("bitErode.bmp");
            bitArray[0].Save("outDilute.bmp");
            bitArray[1].Save("outErode.bmp");
        }

        static Bitmap[] dilute (Bitmap bitOrig, Bitmap bitCopy, Bitmap bitErode, int[,] matrix)
        {
            byte maxRed = 0;
            byte maxGreen = 0;
            byte maxBlue = 0;
            byte minRed = 255;
            byte minGreen = 255;
            byte minBlue = 255;
            int[] pivotCoords = findPivot(matrix);
            int offsetX = pivotCoords[0] - 1;
            int offsetY = pivotCoords[1] - 1;
            //Iterate over picture
            for (int x = 2; x < bitOrig.Width - 2; x ++)
            {
                for (int y = 2; y < bitOrig.Height - 2; y++)
                {
                    //Iterate over Matrix
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            byte redOfCurrentPixel = bitOrig.GetPixel(x - 1 + i + offsetX, y - 1 + j + offsetY).R;
                            byte greenOfCurrentPixel = bitOrig.GetPixel(x - 1 + i + offsetX, y - 1 + j + offsetY).G;
                            byte blueOfCurrentPixel = bitOrig.GetPixel(x - 1 + i + offsetX, y - 1 + j + offsetY).B;

                            if (matrix[i, j] != 0)
                            {
                                //MAXBLOCK
                                if (redOfCurrentPixel > maxRed)
                                {
                                    maxRed = redOfCurrentPixel;
                                }
                                if (greenOfCurrentPixel > maxGreen)
                                {
                                    maxGreen = greenOfCurrentPixel;
                                }
                                if (blueOfCurrentPixel > maxBlue)
                                {
                                    maxBlue = blueOfCurrentPixel;
                                }
                                //MINBLOCK
                                if (redOfCurrentPixel < minRed)
                                {
                                    minRed = redOfCurrentPixel;
                                }
                                if (greenOfCurrentPixel < minGreen)
                                {
                                    minGreen = greenOfCurrentPixel;
                                }
                                if (blueOfCurrentPixel < minBlue)
                                {
                                    minBlue = blueOfCurrentPixel;
                                }
                            }

                        }
                        //After getting max and min values from Matrix area
                        //DILUTEBLOCK
                        Color dilutedColor = Color.FromArgb(maxRed, maxGreen, maxBlue);
                        bitCopy.SetPixel(x, y, dilutedColor);
                        //ERODEBLOCK
                        Color erodedColor = Color.FromArgb(minRed, minGreen, minBlue);
                        bitErode.SetPixel(x, y, erodedColor);
                        //Reset maxValues
                        maxRed = 0;
                        maxGreen = 0;
                        maxBlue = 0;
                        //Reset Minvalues
                        minRed = 255;
                        minGreen = 255;
                        minBlue = 255;
                    }
                }
            }
            return new Bitmap[] { bitCopy, bitErode };
            //return bitCopy;
        }

        static int[] findPivot (int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == 2)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
