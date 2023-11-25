using TetrLoader.Enum;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeInteraction : IgeBase
{
	public string? type { get; set; }
	public int? cid { get; set; }
	public GarbageData data { get; set; }

	//until v15
	public string? sender { get; set; }
	public string? sender_id { get; set; }
	public int? sent_frame { get; set; }

	//from v16
	public string? gameid { get; set; }
	public int? frame { get; set; }

	public override object Clone()
		=> new IgeInteraction()
		{
			cid = cid,
			data = data,
			frame = frame,
			sent_frame = sent_frame,
			gameid = gameid,
			sender = sender,
			sender_id = sender_id,
			type = type,
		};
}
