using System;
using System.Collections;
using System.Collections.Generic;

public class WinningTeam
{
	//Declarations

	public string Sdate { get; set; }
	public string SB { get; set; }
	public string Attendance { get; set; }
	public string QBWinner { get; set; }
	public string CoachWinner { get; set; }
	public string Winner { get; set; }
	public string WinningPts { get; set; }
	public string QBLoser { get; set; }
	public string CoachLoser { get; set; }
	public string Loser { get; set; }
	public string LosingPts { get; set; }
	public string MVP { get; set; }
	public string Stadium { get; set; }
	public string City { get; set; }
	public string State { get; set; }


	public WinningTeam(string Sdate, string SB, string Attendance, string QBWinner, string CoachWinner, string Winner, string WinningPts, string QBLoser, string CoachLoser, string Loser, string LosingPts, string MVP, string Stadium, string City, string State)
	{
		this.Sdate = Sdate;
		this.SB = SB;
		this.Attendance = Attendance;
		this.QBWinner = QBWinner;
		this.CoachWinner = CoachWinner;
		this.Winner = Winner;
		this.WinningPts = WinningPts;
		this.QBLoser = QBLoser;
		this.CoachLoser = CoachLoser;
		this.Loser = Loser;
		this.LosingPts = LosingPts;
		this.MVP = MVP;
		this.Stadium = Stadium;
		this.City = City;
		this.State = State;
	}
}







