namespace TetrLoader.JsonClass.API;

public class LeagueStream
{
	public bool? success { get; set; }
	public RecordData? data { get; set; }
}


public class RecordData
{
	public List<ReplayDataTTRM>? records { get; set; }
}