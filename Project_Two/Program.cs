using System;
using System.IO;

namespace Project_Two
{
	class Program
	{
		static readonly string textFile = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Project.csv";
		static string path = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Report.txt";

		static void Main(string[] args)
		{

			if (File.Exists(textFile))
			{
				using (StreamReader file = new StreamReader(textFile))
				{
					int counter = 0;
					string ln;

					while ((ln = file.ReadLine()) != null)
					{

						Console.WriteLine(ln);
						counter++;
					}
					file.Close();
					Console.WriteLine($"File has {counter} lines.");
				}
			}

		
			using (StreamWriter file = new StreamWriter(path))
			{
				string[] lines = File.ReadAllLines(textFile); ;
				foreach (string line in lines)

				{
					string[] col = line.Split(',');

					WinningTeam team = new WinningTeam(date: col[0], sB: col[1], qBWinner: col[2], coachWinner: col[3], winner: col[4], winningPts: col[5],
					 qBLoser: col[6], coachLoser: col[7], loser: col[8], losingPts: col[9], mVP: col[10], stadium: col[11], city: col[12], state: col[13]);

					WinningTeam team2 = new WinningTeam(winner: col[4], sB: col[1], date: col[0], qBWinner: col[2], mVP: col[10]);

					file.WriteLine(line);

				}
			


				//using (StreamWriter bfile = new StreamWriter(path))
				//{
				//	string[] blines = File.ReadAllLines(textFile); ;
				//	foreach (string line in blines)

				//	{
				//		string[] col = line.Split(',');


				//		WinningTeam team2 = new WinningTeam(winner: col[4], sB: col[1], date: col[0], qBWinner: col[2], mVP: col[10]);


				//		file.WriteLine("testing" + line);
				//		//file.Close();
				//	}





				}

				Console.ReadKey();
			}
		}
	}





