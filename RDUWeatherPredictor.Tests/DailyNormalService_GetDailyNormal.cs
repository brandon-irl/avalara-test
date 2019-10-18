using System;
using RDUWeatherPredictor.Data;
using RDUWeatherPredictor.Services;
using Xunit;

namespace RDUWeatherPredictor.Tests
{
	public class DailyNormalService_GetDailyNormal
	{
		IDailyNormalService _dailyNormalService;
		public DailyNormalService_GetDailyNormal()
		{
			WeatherDbContext context = null; // mock this value
			IAsyncRepository<DailyNormal> repository = new DailyNormalRepository(context);
			this._dailyNormalService = new DailyNormalService(repository);
		}

		[Fact]
		public void DailyNormalService_GetDailyNormal_ReturnsToday()
		{
			// TODO: implement test
			Assert.True(true);
		}
	}
}
