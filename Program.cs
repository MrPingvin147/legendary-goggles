using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//https://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
//https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp

namespace Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Patrick H. Thomsen\Dropbox\Skole Arbejde\Programmering\Tilpasning af dronedata projekt/flyvning1.csv";
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<string> exportSVC = new List<string>();

                List<string>[] dataArray = new List<string>[14];

                for (int i = 0; i < 14; i++)
                {
                    dataArray[i] = new List<string>();
                }

                StringBuilder csv = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    for ( int i = 0; i < 13; i++)
                    {
                        dataArray[i].Add(values[i]);
                    }
                }

                /*for (int y = 0; y < 13; y++)
                {
                    for (int i = 0; i < dataArray[y].Count; i++)
                    {
                        Console.WriteLine(dataArray[y][i]);
                    }
                }*/
                

                for (int i = 2; i < dataArray[2].Count - 1; i++)
                {
                    dataArray[2][i] = dataArray[2][i].Replace(".", string.Empty);

                    dataArray[2][i] = dataArray[2][i].Insert(1, ".");


                    dataArray[3][i] = dataArray[3][i].Replace(".", string.Empty);

                    dataArray[3][i] = dataArray[3][i].Insert(2, ".");
                }


                for (int i = 0; i < dataArray[3].Count - 1; i++)
                {
                    dataArray[13].Add(dataArray[2][i] + ", " + dataArray[3][i]);

                    csv.AppendLine(dataArray[0][i] + ";" + dataArray[1][i] + ";" + dataArray[2][i] + ";" + dataArray[3][i] + ";" + dataArray[4][i] + ";" + dataArray[5][i] + ";" + dataArray[6][i] + ";" + dataArray[7][i] + ";" + dataArray[8][i] + ";" + dataArray[9][i] + ";" + dataArray[10][i] + ";" + dataArray[11][i] + ";" + dataArray[12][i] + ";" + dataArray[13][i]);
                }
                
                
                File.WriteAllText(@"C:\Users\Patrick H. Thomsen\Dropbox\Skole Arbejde\Programmering\Tilpasning af dronedata projekt/flyvning2.csv", csv.ToString());

            }
        }
    }
}
