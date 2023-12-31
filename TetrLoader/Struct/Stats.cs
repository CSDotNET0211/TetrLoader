﻿namespace TetrLoader.Struct;

	 
public struct Stats
{
	public Stats(double pps, double apm, double vs, string time, bool winner)
	{
		PPS = pps;
		APM = apm;
		VS = vs;
		Time = time;
		Winner = winner;
	}

	public double PPS { get; set; }
	public double APM { get; set; }
	public double VS { get; set; }
	public string Time { get; set; }
	public bool Winner { get; set; }
}