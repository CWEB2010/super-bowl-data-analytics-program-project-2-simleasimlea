namespace Project_Two
{
	internal class WinningTeam
	{
		private object date;
		private object sB;
		private object qBWinner;
		private object coachWinner;
		private object winner;
		private object winningPts;
		private object qBLoser;
		private object coachLoser;
		private object loser;
		private object losingPts;
		private object mVP;
		private object stadium;
		private object city;
		private object state;

		public WinningTeam(string v)
		{
		}

		public WinningTeam(string winner, string sB, string date, string qBWinner, string mVP)
		{
			this.winner = winner;
			this.sB = sB;
			this.date = date;
			this.qBWinner = qBWinner;
			this.mVP = mVP;
		}

		public WinningTeam(object date, object sB, object qBWinner, object coachWinner, object winner, object winningPts, object qBLoser, object coachLoser, object loser, object losingPts, object mVP, object stadium, object city, object state)
		{
			this.date = date;
			this.sB = sB;
			this.qBWinner = qBWinner;
			this.coachWinner = coachWinner;
			this.winner = winner;
			this.winningPts = winningPts;
			this.qBLoser = qBLoser;
			this.coachLoser = coachLoser;
			this.loser = loser;
			this.losingPts = losingPts;
			this.mVP = mVP;
			this.stadium = stadium;
			this.city = city;
			this.state = state;
		}
	}
}