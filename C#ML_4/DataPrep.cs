using Deedle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);

            string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "input-data");
            string rawDataPath = Path.Combine(dirPath, "eurusd-daily.csv");
            Console.WriteLine("Loading...");

            var rawDF = Frame.ReadCsv(
                rawDataPath,
                hasHeaders: true,
                schema: "Date,float,float,float",
                inferTypes: false
            );

            //renaming the columns
            rawDF.RenameColumns(c => c.Contains("EUR/USD ") ? c.Replace("EUR/USD ", "") : c);

            rawDF.AddColumn("Open", rawDF["Close"].Shift(1));

            rawDF.AddColumn("DailyReturn", rawDF["Close"].Diff(1) / rawDF["Close"] * 100.0);

            rawDF.AddColumn("Target", rawDF["DailyReturn"].Shift(-1));

            rawDF.Print();

            //saving The Data
            string ohlcPath = Path.Combine(dirPath, "eurousd-ohlc.csv");
            rawDF.SaveCsv(ohlcPath);
        }
    }
}
