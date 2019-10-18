using System;
using System.Threading.Tasks;
using RDUWeatherPredictor.Data;

namespace RDUWeatherPredictor.Services
{
	// This service takes the average of the temperature min & max, and adds 0.1 to the precipitation
	// If climate change is included, all bets are off
	public class DumbPredictionService : IPredictionService<IPrediction>
	{
		private IDailyNormalService _dataService;

		public DumbPredictionService(IDailyNormalService dailyNormalService)
		{
			this._dataService = dailyNormalService;
		}

		public float? CalculatePredictedPrecipitation(DailyNormal dailyNormal, bool useClimateChange = false)
		{
			if (dailyNormal.NormalPrecipitation == null)
				return null;
			return dailyNormal.NormalPrecipitation + (useClimateChange ? 10.0f : 0.1f);
		}

		public float CalculatePredictedTemperatureF(DailyNormal dailyNormal, bool useClimateChange = false)
		{
			return ((dailyNormal.NormalMaxTempF + dailyNormal.NormalMinTempF) / 2) + (useClimateChange ? 100f : 0f);
		}

		public async Task<IPrediction> Predict() => await Predict(DateTime.Now.DayOfYear);
		public async Task<IPrediction> Predict(int julianDay, bool useClimateChange = false)
		{
			var normal = await _dataService.GetDailyNormal(julianDay);
			return new SimplePrediction(CalculatePredictedTemperatureF(normal, useClimateChange), CalculatePredictedPrecipitation(normal, useClimateChange));
		}
	}
}