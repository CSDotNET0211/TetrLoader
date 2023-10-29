﻿using TetrLoader.JsonClass.Event;
using TetrLoader.Struct;

namespace TetrLoader
{
	public interface IReplayData
	{
		 List<Event>? GetReplayEvents(int playerIndex, int replayIndex);
		 int GetPlayerCount();
		 Stats GetReplayStats(int playerIndex, int replayIndex);
		  int GetGameTotalFrames(int replayIndex);
		 string GetUsername(int playerIndex);
		 int GetReplayCount();
		 
		







	}


}