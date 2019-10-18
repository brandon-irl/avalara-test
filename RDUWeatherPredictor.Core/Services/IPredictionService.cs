using System;
using System.Threading.Tasks;
using RDUWeatherPredictor.Data;

namespace RDUWeatherPredictor.Services
{
	public interface IPredictionService<T>
	{
		Task<T> Predict();
		Task<T> Predict(int julianDay, bool useClimateChange = false);
	}
}