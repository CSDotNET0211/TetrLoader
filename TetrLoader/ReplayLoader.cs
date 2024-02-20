using System.Text.Json;
using TetrLoader.Enum;
using TetrLoader.JsonClass;
using TetrLoader.JsonClass.Event;

namespace TetrLoader
{
	public abstract class ReplayLoader
	{
		


		/// <summary>
		/// Parse json replay data
		/// </summary>
		/// <param name="jsonString"></param>
		/// <param name="replayKind"></param>
		/// <returns>Parsed replay object. ReplayDataTTR or ReplayDataTTRM</returns>
		/// <exception cref="Exception"></exception>
		public static IReplayData ParseReplay(ref string jsonString, ReplayKind replayKind)
		{
			IReplayData? replay;
			if (replayKind == ReplayKind.TTR)
				replay = JsonSerializer.Deserialize<ReplayDataTTR>(jsonString);
			else
				replay = JsonSerializer.Deserialize<ReplayDataTTRM>(jsonString);

			if (replay == null)
				throw new Exception("Failed to convert json file.\r\n" +
				                    "Supported json file is TETR.IO replay(.ttr | .ttrm) only.");

			return replay;
		}
	}


	/// <summary>
	/// 試合中のデータ、プレイヤーの数分だけリストの個数がある
	/// </summary>
	public class PlayDataTTRM
	{
		/// <summary>
		/// プレイヤーの情報に関するデータ
		/// </summary>
		public List<Board> board { get; set; }

		/// <summary>
		/// リプレイの操作に関するデータ
		/// </summary>
		public List<ReplayEvent> replays { get; set; }
	}


	public class Board
	{
		public User? user { get; set; } = null;
		public bool? active { get; set; } = null;
		public bool? success { get; set; } = null;
		public int? winning { get; set; } = null;

		//from v16, User structure was combined to endcontext
		public string? id { get; set; } = null;
		public string? username { get; set; } = null;
	}

	/// <summary>
	/// 試合の入力データ
	/// </summary>
	public class ReplayEvent
	{
		/// <summary>
		/// 総フレーム数
		/// </summary>
		public int? frames { get; set; } = null;

		public List<Event>? events { get; set; } = null;
	}


	public class Export
	{
		public bool? successful { get; set; } = null;

		public string? gameoverreason { get; set; } = null;

		//public EventFullReplayData? replay { get; set; } = null;
		//	public EventFullSourceData? source { get; set; } = null;
		public EventFullOptionsData? options { get; set; } = null;

		public EventFullStatsData? stats { get; set; } = null;

		// public EventTargets? targets { get; set; } = null;
		public int? fire { get; set; } = null;
		public EventFullGameData? game { get; set; } = null;
		public EventKillerData? killer { get; set; } = null;
		public AggregateStats? aggregatestats { get; set; } = null;
	}


	public class AggregateStats
	{
		public double? apm { get; set; } = null;
		public double? pps { get; set; } = null;
		public double? vsscore { get; set; } = null;
	}
}