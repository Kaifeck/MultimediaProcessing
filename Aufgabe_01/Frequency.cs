using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Set up dictionary
                int currentValueOfCharInDictionary = 0;
                string text = System.IO.File.ReadAllText(args[0]);
                Dictionary<char, int> relHaeufigkeit = new Dictionary<char, int>();
                for (int i = 0; i < text.Length; i++)
                {
                    char currentlySelectedCharFromText = text[i];
                    bool checkIfCharIsInDoctionary = relHaeufigkeit.ContainsKey(currentlySelectedCharFromText);
                    if (checkIfCharIsInDoctionary == true)
                    {
                        relHaeufigkeit.TryGetValue(currentlySelectedCharFromText, out currentValueOfCharInDictionary);
                        currentValueOfCharInDictionary += 1;
                        relHaeufigkeit.Remove(currentlySelectedCharFromText);
                        relHaeufigkeit.Add(currentlySelectedCharFromText, currentValueOfCharInDictionary);
                        currentValueOfCharInDictionary = 0;
                    }
                    else
                    {
                        relHaeufigkeit.Add(currentlySelectedCharFromText, 1);
                    }
                }
                //printdictionary(relHaeufigkeit);
                //Create File to Write
                int j = 0;
                string[] lines = new string[relHaeufigkeit.Count+1];
                double sumOfAllChars = (double)relHaeufigkeit.Sum(val => val.Value);
                foreach (KeyValuePair<char, int> kvp in relHaeufigkeit)
                {
                    Console.WriteLine("Character: " + kvp.Key + " Häufigkeit: " + Math.Round(kvp.Value/sumOfAllChars, 5)*100 + "%");
                    lines[j] = kvp.Key + "\t" + Math.Round(kvp.Value / sumOfAllChars, 5) * 100 + "%";
                    j++;
                }
                //Add in entropy for good Measure:
                double returnedEntropy = calculateEntropy(relHaeufigkeit, sumOfAllChars);
                lines[lines.Length - 1] = "Entropy: " + returnedEntropy.ToString();
                calculateEntropy(relHaeufigkeit, sumOfAllChars);
                //Write File
                System.IO.File.WriteAllLines(args[1], lines);
                Console.ReadLine();

            } catch (Exception e)
            {
                Console.WriteLine("There seems to have been an Error!");
            }
        }

        static void printdictionary(Dictionary<char, int> relativeHaufigkeitInPrint)
        {
            foreach (KeyValuePair<char, int> kvp in relativeHaufigkeitInPrint)
            {
                Console.WriteLine("Character: " + kvp.Key + " Anzahl: " + kvp.Value);

            }
        }

        static double calculateEntropy(Dictionary<char, int> relHaufigkeitenInCalcEntropy, double sumOfAllCharsInCalcEntropy)
        {
            // sum of p_x * log_zur_Basis_2(1 / p_x )
            double entropy = 0;
            foreach (KeyValuePair<char, int> kvp in relHaufigkeitenInCalcEntropy)
            {
                entropy += (kvp.Value / sumOfAllCharsInCalcEntropy) * Math.Log(1/(kvp.Value/sumOfAllCharsInCalcEntropy), 2);
            }
            return entropy;
        }

        static void duffman(Dictionary<char, int> relHaeafigkeitForHuffman, double sumOfAllCharsInDictionary)
        {
            
        }
    }
}
