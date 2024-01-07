using System.Diagnostics;
using System.Text.Json;
using TetrLoader.Enum;
using TetrLoader.Ige;
using TetrLoader.JsonClass.Event;
using TetrLoader.Struct;

namespace TetrLoader.JsonClass;

/// <summary>
/// リプレイファイルのデータ
/// </summary>
public class ReplayDataTTRM : IReplayData
{
	public string? _id { get; set; } = null;
	public string? shortid { get; set; } = null;
	public bool ismulti { get; set; } = false;
	public List<EndContext>? endcontext { get; set; } = null;

	public string? ts { get; set; } = null;
	public GameType? gametype { get; set; } = null;
	public bool? verified { get; set; } = null;

	public string replayid { get; set; }
	public string stream { get; set; }
	public User? user { get; set; }

	/// <summary>
	/// 試合ごとのデータ群
	/// </summary>
	public List<PlayDataTTRM> data { get; set; }

	public string? back { get; set; } = null;

	public int GetGameTotalFrames(int replayIndex)
	{
		int maxFrame = -1;

		foreach (var game in data[replayIndex].replays)
		{
			if (maxFrame < game.frames)
				maxFrame = (int)game.frames;
		}

		return maxFrame;
	}


	public int GetPlayerCount()
		=> data[0].replays.Count;


	public int GetGamesCount()
		=> data.Count;

	public int GetEndEventFrame(string username, int replayIndex)
	{
		var last = GetRawEventByUsername(replayIndex, username).Last(x => x.type == EventType.End);
		return (int)last.frame;
	}

	public EndContext GetEndContext(int playerIndex)
	{
		return endcontext[playerIndex];
	}

	public string[] GetUsernames()
	{
		string[] usernames;
		if (endcontext[0].username == null)
			usernames = endcontext.Select(x => x.user.username).ToArray();
		else
			usernames = endcontext.Select(x => x.username).ToArray();

		return usernames;
	}

	public GameType? GetGameType()
	{
		return gametype;
	}


	public List<TetrLoader.JsonClass.Event.Event> GetReplayEvents(string username, int replayIndex)
	{
		var rawEvent = GetRawEventByUsername(replayIndex, username);
		List<TetrLoader.JsonClass.Event.Event> events = new List<TetrLoader.JsonClass.Event.Event>();

		if (@rawEvent == null)
			throw new Exception();

		foreach (var @event in rawEvent)
		{
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

				case EventType.Keydown:
				case EventType.Keyup:
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
					EventIge eventIge = new EventIge(@event.id,
						(int)@event.frame,
						@event.type,
						@event.data.ToString()
					);

					events.Add(eventIge);
					break;

				default:
					var igetype = @event.type;
					events.Add(@event);
					break;
			}
		}

		return events;
	}

	/// <summary>
	/// this is for ensuring the compatibility with before version
	/// </summary>
	/// <param name="data"></param>
	/// <param name="events"></param>
	public void ProcessReplayData(ReplayDataTTRM data, List<TetrLoader.JsonClass.Event.Event>? events)
	{
		foreach (var endContext in data.endcontext)
		{
			if (endContext.username == null)
			{
				endContext.username = endContext.user.username;
				endContext.id = endContext.user._id;
				endContext.user = null;
			}
		}

		foreach (var game in data.data)
		{
			if (game.board != null)
			{
				foreach (var player in game.board)
				{
					if (player.id == null && player.user != null)
						player.id = player.user._id;
				}
			}

			if (events != null)
			{
				for (var index = 0; index < events.Count; index++)
				{
					var @event = events[index];
					if (@event.type == EventType.Ige)
					{
						dynamic eventDynamic = @event;
						var newdata = eventDynamic.data.id == null ? eventDynamic.data : eventDynamic;

						if (newdata?.data?.data?.sender_id == null)
							continue;

						newdata.data.data.sender_id =
							(newdata.data.data.sender_id as string)?.Substring(0, 24);
						newdata.data.data.gameid = newdata.data.data.sender_id;
					}
					else if (@event.type == EventType.Targets)
					{
						dynamic eventDynamic = @event;

						var targets = eventDynamic.data.data as List<string>;
						for (int i = 0; i < targets.Count; i++)
							targets[i] = targets[i].Substring(0, 24);

						var igeData = new EventIgeData();
						igeData.type = "ige";
						igeData.id = 1337;
						igeData.frame = eventDynamic.frame;

						var igeTarget = new IgeTarget();
						igeData.data = igeTarget;
						igeTarget.targets = targets.ToArray();
						igeTarget.type = "target";

						var newEvent = new EventIge(null, eventDynamic.frame, EventType.Ige, igeData);


						events[index] = newEvent;
					}
					else if (@event.type == EventType.Full)
					{
						var eventFull = @event as EventFull;
						if (eventFull.data.options.handling == null)
						{
							eventFull.data.options.handling = eventFull.data.game.handling;
						}
					}
				}
			}
		}
	}

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

		var board = GetRawBoardByUsername(replayIndex, username);
		if (board?.success == null)
			result.Winner = false;
		else
			result.Winner = (bool)board.success;


		return result;
	}

	public string GetUsername(int playerIndex, int version)
	{
		if (version <= 15)
			return endcontext[0].naturalorder == playerIndex
				? endcontext[0].user.username
				: endcontext[1].user.username;
		else // (version >= 16)
		{
			return endcontext[0].naturalorder == playerIndex
				? endcontext[0].username
				: endcontext[1].username;
		}
	}

	//board and replay item is not synchronized index, needed to compare by username
	public List<Event.Event>? GetRawEventByUsername(int replayIndex, string username)
	{
		foreach (var rawEventbyPlayer in data?[replayIndex].replays)
		{
			var eventFull = rawEventbyPlayer.events?.First(ev => ev.type == EventType.Full);
			string eventFullStr = eventFull.data.ToString();
			var eventUserName = Util.GetUsername(ref eventFullStr);
			if (eventUserName == username)
				return rawEventbyPlayer.events;
		}

		return null;
	}

	public Board? GetRawBoardByUsername(int replayIndex, string username)
	{
		foreach (var boardbyPlayer in data?[replayIndex].board)
		{
			var boardUsername = boardbyPlayer.user?.username;
			if (boardUsername == null)
				boardUsername = boardbyPlayer.username;

			if (boardUsername == username)
				return boardbyPlayer;
		}

		return null;
	}
}

public class ReplayDataTTRMData
{
}