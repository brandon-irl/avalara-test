using Microsoft.EntityFrameworkCore;
using RDUWeatherPredictor.Data;

namespace RDUWeatherPredictor.Client
{
	internal class ConsoleWeatherDbContext : WeatherDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(Utility.GetConnectionString());
	}
}