using TetrLoader.Enum;
using TetrLoader.JsonClass;
using TetrLoader.JsonClass.Event;
using TetrLoader.Struct;

namespace TetrLoader
{
	public interface IReplayData
	{
		List<Event>? GetReplayEvents(string username, int gameIndex);
		int GetPlayerCount();
		Stats GetReplayStats(string username, int replayIndex);
		int GetGameTotalFrames(int replayIndex);
		string GetUsername(int playerIndex, int version);

		int GetGamesCount();

		//EventFullData GetEventFullData(string rawEvents);
		int? GetEndEventFrame(string username, int replayIndex);
		EndContext GetEndContext(int playerIndex);
		string[] GetUsernames();

		GameType? GetGameType();
	}
}