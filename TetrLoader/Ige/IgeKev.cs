using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeKev : IgeBase
{
	public string? type { get; set; }
	public int? fire { get; set; }

	//until v15, this is string username
	//from v16, this is Victim class
	public object? victim { get; set; }
	public Killer? killer { get; set; }
	
	//not used
	public string? gameid { get; set; }

	public override object Clone()
	{
		object victim;
		if (this.victim is Victim newvictim)
			victim = newvictim.Clone();
		else
			victim = this.victim;

		return new IgeKev()
		{
			type = type,
			fire = fire,
			victim = victim,
			killer = killer
		};
	}
}

public class Victim : ICloneable
{
	public string? gameid { get; set; }
	public string? name { get; set; }

	public object Clone()
		=> new Victim() { gameid = gameid, name = name };
}

public struct Killer
{
	public string? name { get; set; }
	public string? type { get; set; }

	//from v16
	public string? gameid { get; set; }
}