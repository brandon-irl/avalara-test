using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RDUWeatherPredictor.Data
{
	public interface IAsyncRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
	}

	public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
	{
		protected readonly WeatherDbContext _context;

		public BaseAsyncRepository(WeatherDbContext context)
		{
			this._context = context;
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>()
				.FindAsync(id);
		}
	}
}