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

		foreach (var replay in data[replayIndex].replays)
		{
			if (maxFrame < replay.frames)
				maxFrame = (int)replay.frames;
		}

		return maxFrame;
	}


	public int GetPlayerCount()
		=> data[0].replays.Count;


	public int GetGamesCount()
		=> data.Count;

	public int? GetEndEventFrame(string username, int replayIndex)
	{
		var last = GetRawEventByUsername(replayIndex, username)?.Last(x => x.type == EventType.End);
		return last?.frame;
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


	public List<TetrLoader.JsonClass.Event.Event>? GetReplayEvents(string username, int replayIndex)
	{
		var rawEvent = GetRawEventByUsername(replayIndex, username);
		List<TetrLoader.JsonClass.Event.Event> events = new List<TetrLoader.JsonClass.Event.Event>();

		if (@rawEvent == null)
			return null;


		foreach (var @event in rawEvent)
			events.Add(Util.ProcessEvent(@event));

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
				/*bool fullFlag = false;
				bool startFlag = false;
				foreach (var ev in events)
				{
					if (ev.type == EventType.Start)
					{
						startFlag = true;
					}

					//TODO:fullを追加してfullとendの強制対応を消す	
					if (ev.type == EventType.Full)
					{
						fullFlag = true;
					}
				}

				if (!fullFlag)
				{
					var eventEnd = (events.LastOrDefault(ev => ev.type == EventType.End) as EventEnd).data;
					events.Insert(0, new Event.EventFull(0, 0, EventType.Full, eventEnd.export));
				}

				if (!startFlag)
					events.Insert(0, new Event.Event(0, 0, EventType.Start));
*/
				for (var eventIndex = 0; eventIndex < events.Count; eventIndex++)
				{
					var @event = events[eventIndex];
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


						events[eventIndex] = newEvent;
					}
					else if (@event.type == EventType.Full)
					{
						var eventFull = @event as EventFull;
						eventFull.data.options.handling ??= eventFull.data.game.handling;
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
			var options = (rawEventbyPlayer.events?.FirstOrDefault(ev => ev.type == EventType.Full) as EventFull)?.data
				.options;

			options ??= JsonSerializer
				.Deserialize<EventEndData>(rawEventbyPlayer.events?.LastOrDefault(ev => ev.type == EventType.End).data
					.ToString()).export.options;

			if (options == null)
				throw new Exception("not full or end event detected");

			var eventUserName = Util.GetUsernameFromFullData(options);
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