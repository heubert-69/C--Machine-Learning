using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using Deedle;


//Data Analysis with Deedle 
namespace DataAnalysis
{
	class Program
	{
		static void Main(string[] args)
		{
			//Read AAPL Stock Data 2010-2013
			var root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
			var aaplData = Frame.ReadCsv(Path.Combine(root, "table_aapl.csv"));

			Console.WriteLine("--Raw Data--");
			aaplData.Print();


			//Setting Data Field as Index
			var aapl = aaplData.IndexRows<String>("Date").SortRowsByKey();
			Console.WriteLine("--After Indexing");
			aaplData.Print();

			


			//calculate the percentage change (Returns)
			var openCloseChange = ((aapl.GetColumn<double>("Close") - aapl.GetColumn<double>("Open")) / aapl.GetColumn<double>("Open") * 100.0);
			aapl.AddColumn("openCloseChange", openCloseChange);
			Console.WriteLine("After Adding The New Columns");
			aapl.Print();
			


			//Shifting The close prices by one row and calculating the daily returns
			var dailyReturn = aapl.Diff(1).GetColumn<double>("Close") / aapl.GetColumn<double>("Close") * 100.0;
			aapl.AddColumn("dailyReturn", dailyReturn);
			Console.WriteLine("--Shift--");
			aapl.Print();

			Console.ReadKey();
		}
	}
}
