﻿using TetrLoader.Ige;

namespace TetrLoader.JsonClass;

public class IgeData : ICloneable
{
	public IgeData Clone()
	{
		IgeData newdata = new IgeData();
		newdata.id = id;
		newdata.frame = frame;
		newdata.type = type;
		newdata.data = (GarbageData)data.Clone();
		newdata.sender = sender;
		newdata.sender_id = sender_id;
		newdata.sent_frame = sent_frame;
		newdata.cid = cid;
		newdata.lines = lines;
		newdata.column = column;
		newdata.active = active;


		return newdata;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public int? id { get; set; }
	public int frame { get; set; }
	public string type { get; set; }
	public GarbageData data { get; set; }
	public string sender { get; set; }
	public string? sender_id { get; set; }
	public int sent_frame { get; set; }
	public int? cid { get; set; }
	public int lines { get; set; }
	public int column { get; set; }
	public bool active { get; set; }
}