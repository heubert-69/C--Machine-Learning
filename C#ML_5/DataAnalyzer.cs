using Accord.Statistics;
using Deedle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);

            // Read in the House Price dataset
            string dataDirPath = "C# Machine Learning/C#ML_5/input-data";

            // Load the data into a data frame
            string dataPath = Path.Combine(dataDirPath, "train.csv");
            Console.WriteLine("Loading {0}\n", dataPath);
            var houseDF = Frame.ReadCsv(
                dataPath,
                hasHeaders: true,
                inferTypes: true
            );

            // Categorical Variable #1: Building Type
            Console.WriteLine("\nCategorical Variable #1: Building Type");
            var buildingTypeDistribution = houseDF.GetColumn<string>(
                "BldgType"
            ).GroupBy<string>(x => x.Value).Select(x => (double)x.Value.KeyCount);
            buildingTypeDistribution.Print();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            // Continue with other analyses using console output
            // Remove all DataBarBox and HistogramBox code

            // For histogram-like output, you can create text-based histograms:
            Console.WriteLine("\nFirst Floor Square Feet Distribution:");
            var firstFloorValues = houseDF.DropSparseRows()["1stFlrSF"].ValuesAll.ToArray();
            PrintTextHistogram(firstFloorValues, 20, "First Floor Square Feet");

            Console.WriteLine("\nDONE!!!");
            Console.ReadKey();
        }

        static void PrintTextHistogram(double[] values, int bins, string title)
        {
            var histogram = new Histogram(values, bins);

            Console.WriteLine(title);
            Console.WriteLine(new string('-', 50));

            for (int i = 0; i < bins; i++)
            {
                var range = $"{histogram.Bins[i].Range.Min:F0}-{histogram.Bins[i].Range.Max:F0}";
                var count = histogram.Bins[i].Value;
                var bar = new string('*', (int)(count / (double)values.Length * 40));

                Console.WriteLine($"{range,-15}: {bar} ({count})");
            }
        }
    }
}
