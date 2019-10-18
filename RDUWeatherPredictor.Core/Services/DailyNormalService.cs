using System;
using System.Threading.Tasks;
using RDUWeatherPredictor.Data;

namespace RDUWeatherPredictor.Services
{
	public interface IDailyNormalService
	{
		Task<DailyNormal> GetDailyNormal(int dailyNormalId);
	}

	public class DailyNormalService : IDailyNormalService
	{
		private readonly IAsyncRepository<DailyNormal> _repository;

		public DailyNormalService(IAsyncRepository<DailyNormal> repository)
		{
			this._repository = repository;
		}

		public async Task<DailyNormal> GetDailyNormal(int julianDay) {
			return await _repository.GetByIdAsync(julianDay + (DateTime.Now > new DateTime(DateTime.Now.Year, 2, 28) && !DateTime.IsLeapYear(DateTime.Now.Year) ? 1 : 0));	// Add 1 if this isn't a leap year and it's after 2/28
		}
	}
}