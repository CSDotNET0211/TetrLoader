using TetrLoader.JsonClass.API;

namespace TetrLoader.JsonClass
{
	public class User
	{
		public string? _id { get; set; }
		public string? username { get; set; }
		public string? role { get; set; }
		public double? xp { get; set; }
		public League league { get; set; }
		public bool? supporter { get; set; }
		public bool? verified { get; set; }
		public string? country { get; set; }

		public override bool Equals(object? obj)
		{
			return ((User)obj)._id == _id;
		}

		public override int GetHashCode()
		{
			return _id.GetHashCode();
		}
	}
}