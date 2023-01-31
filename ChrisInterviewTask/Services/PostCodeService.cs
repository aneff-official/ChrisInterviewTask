namespace ChrisInterviewTask.Services
{
	public class PostCodeService : IPostCodeService
	{
		private const string KEY = "BasePostCodeURL";
		private readonly IConfiguration _config;

		public PostCodeService(IConfiguration config)
		{
			_config = config;
		}

		public async Task<object?> Get(string postCode)
		{
			var baseUrl = _config.GetValue<string>(KEY);
			var url = $"{baseUrl}{postCode}";

			using (var client = new HttpClient())
			{
				var endpoint = new Uri(url);
				var response = await client.GetAsync(endpoint);

				return response == null ? new object() : await response.Content.ReadAsStringAsync();
			}
		}
	}
}