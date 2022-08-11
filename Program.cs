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

                List<string> GPSLong = new List<string>();
                List<string> GPSLat = new List<string>();

                StringBuilder csv = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    GPSLong.Add(values[2]);
                    GPSLat.Add(values[3]);
                }

                for (int i = 2; i < GPSLong.Count - 1; i++)
                {
                    GPSLong[i] = GPSLong[i].Replace(".", string.Empty);

                    GPSLong[i] = GPSLong[i].Insert(1, ".");


                    GPSLat[i] = GPSLat[i].Replace(".", string.Empty);

                    GPSLat[i] = GPSLat[i].Insert(2, ".");
                }

                for (int i = 2; i < GPSLong.Count - 1; i++)
                {
                    exportSVC.Add(GPSLong[i] + ", " + GPSLat[i]);

                    csv.AppendLine(exportSVC[i - 2]);
                }

                

                

                File.WriteAllText(@"C:\Users\Patrick H. Thomsen\Dropbox\Skole Arbejde\Programmering\Tilpasning af dronedata projekt/flyvning2.csv", csv.ToString());

                Console.ReadKey();
            }
        }
    }
}
