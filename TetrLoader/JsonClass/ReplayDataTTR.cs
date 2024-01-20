using System.Text.Json;
using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;
using TetrLoader.Struct;

namespace TetrLoader.JsonClass;

/// <summary>
/// リプレイファイルのデータ
/// </summary>
public class ReplayDataTTR : IReplayData
{
	public User? user { get; set; } = null;

	//TTR
	public string? _id { get; set; } = null;
	public string? shortid { get; set; } = null;
	public bool ismulti { get; set; } = false;
	public EndContext? endcontext { get; set; } = null;

	public string? ts { get; set; } = null;
	public GameType? gametype { get; set; } = null;
	public bool? verified { get; set; } = null;

	/// <summary>
	/// 試合ごとのデータ群
	/// </summary>
	public ReplayEvent? data { get; set; } = null;

	public string? back { get; set; } = null;

	//TODO: implement this
	public int GetGameTotalFrames(int replayIndex)
	{
		return data.frames ?? -1;
	}

	public int GetPlayerCount()
		=> 1;

	public int GetGamesCount()
		=> 1;

//TODO: argumants will be ignored. fix this
	public int? GetEndEventFrame(string username, int replayIndex)
	{
		return data?.events?.Last(x => x.type == EventType.End).frame ?? null;
	}

	public EndContext GetEndContext(int playerIndex)
	{
		return endcontext;
	}

	public string[] GetUsernames()
	{
		return new[] { user.username };
	}

	public GameType? GetGameType()
	{
		return gametype;
	}

	public List<Event.Event>? GetReplayEvents(string username, int replayIndex)
	{
		var rawEvent = data.events;
		List<Event.Event> events = new List<Event.Event>();

		foreach (var @event in rawEvent)
		{
			if (@event == null)
				throw new Exception();

			events.Add(Util.ProcessEvent(@event));
		}

		return events;
	}

	//TODO: not checked the code
	public Stats GetReplayStats(string username, int replayIndex)
	{
		var result = new Stats();
		var events = GetReplayEvents(username, replayIndex);
		var eventEnd = events.Last(ev => ev.type == EventType.End) as EventEnd;
		for (int i = events.Count - 1; i >= 0; i--)
		{
			if (events[i].type == EventType.End)
			{
				eventEnd = events[i] as EventEnd;
				break;
			}
		}

		result.VS = eventEnd.data.export.aggregatestats.vsscore ?? -1;
		result.APM = eventEnd.data.export.aggregatestats.apm ?? -1;
		result.PPS = eventEnd.data.export.aggregatestats.pps ?? -1;

		var frames = GetGameTotalFrames(replayIndex);
		int time = frames / 60;
		result.Time = (time / 60).ToString() + ":" + (time % 60).ToString("00");

		result.Winner = false;
		return result;
	}

	public string GetUsername(int playerIndex, int version)
		=> user.username;
}