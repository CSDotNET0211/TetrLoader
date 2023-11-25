using TetrLoader.Enum;

namespace TetrLoader.Ige;

public class GarbageData : ICloneable
{
	public int? id { get; set; }
	public int? iid { get; set; }
	public int? ackiid { get; set; }
	public string? username { get; set; }
	public string? type { get; set; }
	public bool? active { get; set; }
	public GarbageStatus? status { get; set; }
	public int? delay { get; set; }
	public bool? queued { get; set; }
	public int? amt { get; set; }
	public int? x { get; set; }
	public int? y { get; set; }
	public int? size { get; set; }
	public int? column { get; set; }
	public int? cid { get; set; }
	public bool? firstcycle { get; set; }
	public int? gid { get; set; }


	public object Clone()
	{
		return new GarbageData()
		{
			cid = cid,
			column = column,
			size = size,
			username = username,
			ackiid = ackiid,
			x = x,
			y = y,
			active = active,
			amt = amt,
			queued = queued,
			type = type,
			delay = delay,
			firstcycle = firstcycle,
			id = id,
			iid = iid,
			status = status
		};
	}
}