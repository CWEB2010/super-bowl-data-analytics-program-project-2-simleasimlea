using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Project_Two
{
	class Program
	{
		//static readonly string textFile = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Project.csv";
		//static readonly string path = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Report.txt";


		static void Main(string[] args)
		{
			List<WinningTeam> Team = new List<WinningTeam>();
			string primingValue = "";
			string textFile = "";
			string path = "";

			Console.WriteLine("\nWhat is your name? (Enter X to exit.)");

			primingValue = Convert.ToString(Console.ReadLine());//using primingValue for user name and also to exit out

			if (primingValue != "X" & primingValue != "x")
			{
				/*Temporarily commenting out user input of path, etc. and hard coding for ease - LeAnn
				Console.WriteLine("\nWelcome " + primingValue + "! \n\nWhat is the path (folders & file name)\n" +
				"for the file from which we should read?\n\n" +
				"for example: C:\\Users\\simlea\\Desktop\\MyAssignments\\Project2\\Super_Bowl_Project.csv");
				
				textFile = @Console.ReadLine();

				Console.WriteLine(textFile);

				Console.WriteLine("\nWhat is the path (folders & file name)\n" +
				"for the file to which we should write?\n\n" +
				"for example: C:\\Users\\simlea\\Desktop\\MyAssignments\\Project2\\Super_Bowl_Report.txt");

				path = @Console.ReadLine();

				Console.WriteLine(path); */

				textFile = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Project.csv";
				path = @"C:\Users\simlea\Desktop\MyAssignments\Project2\Super_Bowl_Report.txt";

				Console.Clear();
				Console.WriteLine("The Super Bowl Mega Report is being prepared and written to your location, as instructed.");

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
										//Console.WriteLine(ln); don't need this for report, but can output the list called ln for testing.

									}
									counter++;
								}
							}
							file.Close();
							Console.WriteLine($"FYI: The file being read has {counter} lines.\nIt is outputted below, in addition to your file, for your convenience.\n\n");

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

					Console.WriteLine("Super Bowl Winners\n\n");
					file.WriteLine("Team Name" + "\t\t" + "Year of Win" + "\t\t" + "Winning QB" + "\t\t" + "Winning Coach" + "\t\t" + "MVP" + "\t\t" + "Point Difference");
					Console.WriteLine("Team Name" + "\t\t" + "Year of Win" + "\t\t" + "Winning QB" + "\t\t" + "Winning Coach" + "\t\t" + "MVP" + "\t\t" + "Point Difference");


					foreach (WinningTeam item in Team)
					{

						file.WriteLine(item.Winner + "\t\t" + item.Sdate.Year + "\t\t" + item.QBWinner + "\t\t" + item.CoachWinner + "\t\t" + item.MVP + "\t\t" + (item.WinningPts - item.LosingPts));
						Console.WriteLine(item.Winner + "\t\t" + item.Sdate.Year + "\t\t" + item.QBWinner + "\t\t" + item.CoachWinner + "\t\t" + item.MVP + "\t\t" + (item.WinningPts - item.LosingPts));

					}

					file.Close();


					//Generate a list of the top five attended super bowls
					using (StreamWriter bfile = File.AppendText(path))

					{
						bfile.WriteLine("Attendance" + "\t\t" + "Year of Win" + "\t\t" + "Winning Team" + "\t\t" + "Losing Team" + "\t\t" + "City" + "\t\t" + "State" + "\t\t" + "Stadium");
						Console.WriteLine("Attendance" + "\t\t" + "Year of Win" + "\t\t" + "Winning Team" + "\t\t" + "Losing Team" + "\t\t" + "City" + "\t\t" + "State" + "\t\t" + "Stadium");

						bfile.WriteLine("\n\nTop Five Attended Super Bowls\n");
						Console.WriteLine("\n\nTop Five Attended Super Bowls\n");

						//works...but not the point of exercise. Learning to use LINQ. So, replaced with other code. LeAnn
						//int counter = 0;
						//
						//foreach (WinningTeam item in Team.OrderByDescending(x => x.Attendance))
						//{
						//	if (counter < 5)

						//	{
						//		bfile.WriteLine(item.Attendance + "\t" + item.Sdate.Year + "\t" + item.Winner + "\t" + item.Loser + "\t" + item.City + "\t" + item.State + "\t" + item.Stadium);
						//		Console.WriteLine(item.Attendance + "\t" + item.Sdate.Year + "\t" + item.Winner + "\t" + item.Loser + "\t" + item.City + "\t" + item.State + "\t" + item.Stadium);

						//	}
						//	counter++;
						//}

						var qryTopFive = (from item in Team
										  orderby item.Attendance descending
										  select item).Take(5);

						qryTopFive.ToList().ForEach(s => bfile.WriteLine(s.Attendance + "\t" + s.Sdate.Year + "\t" + s.Winner + "\t" + s.Loser + "\t" + s.City + "\t" + s.State + "\t" + s.Stadium));
						qryTopFive.ToList().ForEach(s => Console.WriteLine(s.Attendance + "\t" + s.Sdate.Year + "\t" + s.Winner + "\t" + s.Loser + "\t" + s.City + "\t" + s.State + "\t" + s.Stadium));

					}

					file.Close();


					//Generate a list of states that hosted the most super bowls
					using (StreamWriter cfile = File.AppendText(path))

					{

						cfile.WriteLine("\n\nStates & Stats on SuperBowls Hosted");
						Console.WriteLine("\n\nStates & Stats on SuperBowls Hosted");

						var qryState = from stateRecord in Team
									   group stateRecord by new
									   {
										   stateRecord.State
									   } into stateGroups
									   from cityGroups in
										   (from city in stateGroups
											orderby city.City, city.Sdate.Year descending, city.Stadium
											group city by new { city.City })
									   orderby stateGroups.Key.State
									   group cityGroups by new { stateGroups.Key.State };


						foreach (var outerGroup in qryState)
						{
							Console.WriteLine($"{ outerGroup.Key.State }: ");
							cfile.WriteLine($"{ outerGroup.Key.State }: ");
							foreach (var detail in outerGroup)
							{
								Console.WriteLine($"\t{ detail.Key.City }");
								cfile.WriteLine($"\t{ detail.Key.City }");

								int v_count = 0;
								foreach (var city in detail)

								{
									Console.WriteLine($"\t\tIn {city.Sdate.Year} - Stadium: { city.Stadium} ");
									cfile.WriteLine($"\t\tIn {city.Sdate.Year} - Stadium: { city.Stadium}");
									v_count++;

								}
								Console.WriteLine($"\n\t\t{outerGroup.Key.State}'s Super Bowl count is { v_count }.");
								cfile.WriteLine($"\n\t\t{outerGroup.Key.State}'s Super Bowl count is { v_count }.");
							}
						}

			
						cfile.Close();



						//Generate a list of players who won MVP more than twice 

						using (StreamWriter dfile = File.AppendText(path))
						{
							dfile.WriteLine("\n\nPlayers Who Won MVP More than Twice:");
							Console.WriteLine("\n\nPlayers Who Won MVP More than Twice:");

							var MVPCount = from m in Team
										   group m by m.MVP into MVPGroup
										   where MVPGroup.Count() > 2
										   orderby MVPGroup.Key
										   select MVPGroup;
	
							foreach (var m in MVPCount)
							{
								Console.WriteLine($"{ m.Key } has {  m.Count() }.");
								dfile.WriteLine($"{ m.Key } has {  m.Count() }.");
							}

							dfile.Close();

						}


						//Which coach lost the most super bowls?

						using (StreamWriter efile = File.AppendText(path))

						{

							efile.WriteLine("\n\nCoach Who Lost the Most Super Bowls:");
							Console.WriteLine("\n\nCoach Who Lost the Most Super Bowls:");

							var CoachLoss = from cl in Team
											.GroupBy(cl => cl.CoachLoser)
											orderby cl.Count()
											//where cl.Max() = cl.Key.Count()
											select new
											 
											{
												cl.Key,
												Most = cl.Count()
						 
											}
											 ;
							
							foreach (var cl in CoachLoss)

							{
								Console.WriteLine($"{ cl.Key } lost { cl.Most }.");
								//efile.WriteLine($"{ cl.Key } lost { cl.Count() }.");
							}

							efile.Close(); 

						}

						primingValue = Convert.ToString(Console.ReadLine().ToUpper());

					}
				}
			}
		}
	}
}








