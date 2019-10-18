using Microsoft.EntityFrameworkCore;

namespace RDUWeatherPredictor.Data
{
	public class WeatherDbContext : DbContext
	{
		public DbSet<DailyNormal> DailyNormals{get;set;}
	}
}