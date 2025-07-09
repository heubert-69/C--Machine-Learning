using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EAGetMail;
using Deedle;

namespace EmailParser
{
	class Program
	{
		private static Frame<int, string> ParseEmails(string[] files)
		{
			//parsing the body and subject of an email
			//storing the record in key value pairs or dictionary
			var rows = files.Enumerable().Select((x, i) => 
			{
				Mail mail = new Mail("Try It"); //Loading each email file into a mail object
				email.Load(x, false);

				//extracting the subject and body
				string emailSubject = email.Subject;
				string textBody = email.TextBody;

				//then we return a key value pair
				return new{emailNum=i, subject= emailSubject, body=textBody};

			});
			return Frame.FromRecords(rows);
		}



		static void Main(string[] args)
		{
			//Get all Raw EML-Format Files
			string dirPath = "C# Machine Learning\C#ML_2"
			string[] emailFiles = Dirctory.GetFiles(dirPath, "*.eml");

			//Parse out the subject
			var emailDF = ParseEmails(emailFiles);
			var labelDF = Frame.ReadCsv(dirPath + "\\SPAMTrain.label", hasHeaders: false, separators: " ", schema: "int,string");
			//Add these label to the email dataframe
			emailDF = AddColumn("is_ham", labelDF.GetColumnAt<string>(0));

			//saved the parsed emails into a csv file
			emailDF.SaveCsv("transformed.csv")

			Console.WriteLine("Data Preparation DONE!");
			Console.ReadKey();
		}
	}

}
