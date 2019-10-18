using System;
using RDUWeatherPredictor.Services;
using Xunit;

namespace RDUWeatherPredictor.Tests
{
	public class PredictionService_Predict
	{
		IPredictionService<IPrediction> _predictionService;
		public PredictionService_Predict()
		{
			IDailyNormalService dailyNormalService = null; //TODO: Mock this value
			this._predictionService = new DumbPredictionService(dailyNormalService);
		}

		[Fact]
		public void PredictionService_PredictTodaysWeather_ReturnsTrue()
		{
			// TODO: implement test
			Assert.True(true);
		}
	}
}