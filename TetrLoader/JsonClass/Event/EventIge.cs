using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TetrLoader;
using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{
	public class EventIge : Event
	{
		public EventIge(int? id, int frame, EventType? type, EventIgeData data) : base(id, frame, type)
		{
			this.data = data;
		}

		public new EventIgeData data { get; set; }

	}
	public class EventIgeData
	{
		public int? id { get; set; }
		public int frame { get; set; }
		public string? type { get; set; }
		public IgeData? data { get; set; }
	}
}
