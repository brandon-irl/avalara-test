using System;

namespace RDUWeatherPredictor.Data
{
	public interface IDailyNormalRepository
	{

	}
	public class DailyNormalRepository : BaseAsyncRepository<DailyNormal>, IDailyNormalRepository
	{
		public DailyNormalRepository(WeatherDbContext context) : base(context) { }
	}
}