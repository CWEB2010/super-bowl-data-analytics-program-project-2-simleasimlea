using System;
using System.Collections.Generic;
using System.IO;


namespace Project_Two
{
	class Program
	{
		static readonly string textFile = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Project.csv";
		static string path = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Report.txt";


		static void Main(string[] args)
		{
			try
			{
				if (File.Exists(textFile))
				{
					using (StreamReader file = new StreamReader(textFile))
						
					{
						int counter = 0;
						string ln;

						List<WinningTeam> Team = new List<WinningTeam>();


						while ((ln = file.ReadLine()) != null)
						{

							string[] col = ln.Split(',');

							{
								if (counter > 1)

								{
									WinningTeam team = new WinningTeam(col[0], col[1], col[2], col[3], col[4], col[5], col[6], col[7], col[8], col[9], col[10], col[11], col[12], col[13], col[14]);
									Team.Add(team);
		
								}
								counter++;
							}
						}
						file.Close();
						Console.WriteLine($"File has {counter} lines.");


					}
				}
			}
			catch (Exception e)
			//catch FileNotFoundException
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}

			using (StreamWriter file = File.CreateText(path))
			

			//using (StreamWriter file = new StreamWriter(path))
			{
				string[] lines = File.ReadAllLines(textFile);
				foreach (string line in lines)

				{
					string[] col = line.Split(',');

					WinningTeam team = new WinningTeam(col[0], col[1], col[2], col[3], col[4], col[5], col[6], col[7], col[8], col[9], col[10], col[11], col[12], col[13], col[14]);

					//file.WriteLine(line);
				}

				file.Close();



				using (StreamWriter bfile = File.AppendText(path))
				//using (StreamWriter bfile = new StreamWriter(path))
				{
					string[] blines = File.ReadAllLines(textFile);

					Console.WriteLine("Winner, Sdate, QBWinner, CoachWinner, MVP, WinningPts,LosingPts");

					foreach (string bline in blines)

					{
						string[] col = bline.Split(',');

						WinningTeam team = new WinningTeam(col[0], col[1], col[2], col[3], col[4], col[5], col[6], col[7], col[8], col[9], col[10], col[11], col[12], col[13], col[14]);
						
						bfile.WriteLine("testing" + team.Winner + string.Format("{0:y yy yyy yyyy}", team.Sdate) + team.QBWinner + team.CoachWinner + team.MVP + team.WinningPts + team.LosingPts);

					}

					bfile.Close();
				}


				Console.ReadKey();
			}
		}
	}
}







