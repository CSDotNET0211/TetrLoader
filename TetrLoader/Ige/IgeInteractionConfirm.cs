using System.Text.Json.Serialization;
using TetrLoader.Enum;
using TetrLoader.JsonClass;
using TetrLoader.JsonClass.Event;

namespace TetrLoader.Ige;

public class IgeInteractionConfirm : IgeBase
{
	public string? type { get; set; }

	public object data { get; set; }
	public int? cid { get; set; }

	//until v15
	public string? sender { get; set; }
	public string? sender_id { get; set; }
	public int? sent_frame { get; set; }

	//from v16
	public string? gameid { get; set; }
	public int? frame { get; set; }


	public override object Clone()
		=> new IgeInteractionConfirm()
		{
			sent_frame = sent_frame,
			cid = cid,
			data = data,
			frame = frame,
			type = type,
			gameid = gameid,
			sender = sender_id,
			sender_id = sender_id,
		};
}

public struct IgeInteractionConfirmTargetEd
{
	public string type { get; set; }
	public bool value { get; set; }
}