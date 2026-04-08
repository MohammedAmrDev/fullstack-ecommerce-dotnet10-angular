namespace Ecom.Core.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string type) : base ($"{type} is not found") { }
	}
}
