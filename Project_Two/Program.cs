﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Project_Two
{
	class Program
	{
		static readonly string textFile = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Project.csv";
		static readonly string path = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Report.txt";

		static void Main(string[] args)
		{
			List<WinningTeam> Team = new List<WinningTeam>();

			try
			{
				if (File.Exists(textFile))
				{
					using (StreamReader file = new StreamReader(textFile))

					{
						int counter = 0;
						string ln;
						Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

						while ((ln = file.ReadLine()) != null)

						{

							string[] col = CSVParser.Split(ln);

							{
								//added this because I was going to skip the header, but for some reason I don't have to...figure out why it is skipping
								if (counter > 0)

								{
									WinningTeam team = new WinningTeam(col[0], col[1], col[2], col[3], col[4], col[5], col[6], col[7], col[8], col[9], col[10], col[11], col[12], col[13], col[14]);
									Team.Add(team);
									Console.WriteLine(ln);

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
			//maybe later add specific exception such as catch FileNotFoundException
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}


			using (StreamWriter file = File.CreateText(path))

			{

			file.WriteLine("Team Name" + "\t" + "Year of Win" + "\t" + "Winning QB" + "\t" + "Winning Coach" + "\t" + "MVP" + "\t" + "Point Difference");
			Console.WriteLine("Team Name" + "\t" + "Year of Win" + "\t" + "Winning QB" + "\t" + "Winning Coach" + "\t" + "MVP" + "\t" + "Point Difference");


			foreach (WinningTeam item in Team)
			{

				file.WriteLine(item.Winner + "\t" + item.Sdate.Year + "\t" + item.QBWinner + "\t" + item.CoachWinner + "\t" + item.MVP + "\t" + (item.WinningPts - item.LosingPts));
				Console.WriteLine(item.Winner + "\t" + item.Sdate.Year + "\t" + item.QBWinner + "\t" + item.CoachWinner + "\t" + item.MVP + "\t" + (item.WinningPts - item.LosingPts));

			}

			file.Close();


				using (StreamWriter bfile = File.AppendText(path))
				//Generate a list of the top five attended super bowls

				{

					bfile.WriteLine("\n\nCreate the right headings, LeAnn");
					Console.WriteLine("\n\nCreate the right headings, LeAnn");

					int counter = 0;

					foreach (WinningTeam item in Team.OrderByDescending(x => x.Attendance))
					{
						if (counter < 5)

						{
							bfile.WriteLine(item.Sdate.Year + "\t" + item.Winner + "\t" + item.Loser + "\t" + item.City + "\t" + item.State + "\t" + item.Stadium);
						}
						counter++;
					}




				}

			file.Close();
			Console.ReadKey();
		}
	}
}
}







