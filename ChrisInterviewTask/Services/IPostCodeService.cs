namespace ChrisInterviewTask.Services
{
	public interface IPostCodeService
	{
		Task<object?> Get(string postCode);
	}
}