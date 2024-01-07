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

	//TODO: fix this
	public int GetGameTotalFrames(int replayIndex)
	{
		return data.frames ?? -1;
	}

	public int GetPlayerCount()
		=> 1;

	public int GetGamesCount()
		=> 1;

//TODO: argumants will be ignored. fix this
	public int GetEndEventFrame(string username, int replayIndex)
	{
		return data.events.Last(x => x.type == EventType.End).frame ?? -1;
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

			switch (@event.type)
			{
				case EventType.Start:
					events.Add(@event);
					break;

				case EventType.End:
					events.Add(new EventEnd
					(
						@event.id,
						(int)@event.frame,
						@event.type,
						JsonSerializer.Deserialize<EventEndData>(@event.data.ToString())
					));
					break;

				case EventType.Full:
					events.Add(new EventFull
					(
						@event.id,
						(int)@event.frame,
						@event.type,
						JsonSerializer.Deserialize<EventFullData>(@event.data.ToString())
					));
					break;

				case EventType.Keyup:
				case EventType.Keydown:
					events.Add(new EventKeyInput
					(
						@event.id,
						(int)@event.frame,
						@event.type,
						JsonSerializer.Deserialize<EventKeyInputData>(@event.data.ToString())
					));
					break;

				case EventType.Targets:
					events.Add(new EventTargets(
						@event.id,
						(int)@event.frame,
						@event.type,
						JsonSerializer.Deserialize<EventTargetsData>(@event.data.ToString())
					));
					break;

				case EventType.Ige:
					events.Add(new EventIge(
						@event.id,
						(int)@event.frame,
						@event.type,
						JsonSerializer.Deserialize<EventIgeData?>(@event.data.ToString())
					));
					break;

				default:
					events.Add(@event);
					break;
			}
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