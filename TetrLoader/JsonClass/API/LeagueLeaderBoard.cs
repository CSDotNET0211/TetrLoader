namespace TetrLoader.JsonClass.API;

public class LeagueLeaderBoard
{
	public bool? success { get; set; }
	public LeagueLeaderBoardData data { get; set; }
}

public class LeagueLeaderBoardData
{
	public List<User> users { get; set; }
}

public class League
{
	public int? gamesplayed { get; set; }
	public int? gameswon { get; set; }
	public double? rating { get; set; }
	public double? glicko { get; set; }
	public double? rd { get; set; }
	public string rank { get; set; }
	public string bestrank { get; set; }
	public double? apm { get; set; }
	public double? pps { get; set; }
	public double? vs { get; set; }
	public bool? decaying { get; set; }
}