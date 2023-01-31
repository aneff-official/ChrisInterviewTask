using Microsoft.Extensions.Caching.Memory;

namespace ChrisInterviewTask.Services
{
	public class CachedPostCodeService : IPostCodeService
	{
		private readonly IMemoryCache _memoryCache;
		private readonly IPostCodeService _postCodeService;
		public CachedPostCodeService(IPostCodeService postCodeService, IMemoryCache memoryCache)
		{
			_postCodeService = postCodeService;
			_memoryCache = memoryCache;
		}

		public async Task<object?> Get(string postCode)
		{
			return await _memoryCache.GetOrCreateAsync(postCode,
				async entry =>
				{
					entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
					return await _postCodeService.Get(entry.Key.ToString()!);
				}
			);
		}
	}
}