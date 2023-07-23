using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrLoader;
using TetrLoader.Enum;

namespace TetrLoader.JsonClass.Event
{
	public class EventKeyInput : TetrLoader.JsonClass.Event.Event
	{
		public EventKeyInput(int? id, int frame, EventType? type, EventKeyInputData data) : base(id, frame, type)
		{
			this.data = data;
		}

		public new EventKeyInputData data { get; set; } 

	}

	public class EventKeyInputData
	{
		public string key { get; set; }
		public double subframe { get; set; }
		public bool hoisted { get; set; }
	}

}
