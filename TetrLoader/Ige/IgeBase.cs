namespace TetrLoader.Ige;

public abstract class IgeBase : ICloneable
{
	public string type;
	public abstract object Clone();
}