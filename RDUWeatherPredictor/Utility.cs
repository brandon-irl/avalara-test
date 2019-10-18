using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RDUWeatherPredictor.Services;

namespace RDUWeatherPredictor.Client
{
	public static class Utility
	{

		public static IPredictionService<IPrediction> GetPredictionService(string predictionService, IDailyNormalService service)
		{
			switch (predictionService.ToLowerInvariant())
			{
				default:
					return new DumbPredictionService(service);
			}
		}

		public static string GetConnectionString()
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")?
				.Build();
			return config["ConnectionStrings:DefaultConnection"];
		}
		public static bool IsInputValid(string[] input)
		{
			if (input == null)
				return true;
			var filteredInput = input.ToList().Where(_ => !_.StartsWith('-') && !_.StartsWith("--"));
			var result = true;
			if (filteredInput.Count() > 0)
				result &= IsDigitAndInRange(filteredInput.ElementAt(0), 0, 367);
			if (filteredInput.Count() > 1)
				result &= IsDigitAndInRange(filteredInput.ElementAt(1), DateTime.MinValue.Month - 1, DateTime.MaxValue.Month + 1);
			if (filteredInput.Count() > 2)
				result &= IsDigitAndInRange(filteredInput.ElementAt(2), DateTime.MinValue.Year - 1, DateTime.MaxValue.Year + 1);
			return result;
		}

		private static bool IsDigitAndInRange(string input, int min, int max) => input.Trim().All(_ => Char.IsDigit(_)) && Int32.TryParse(input, out var i) && i > min && i < max;

		public static DateTime TranslateInput(string[] input, bool useJulianDay = false)
		{
			if (!IsInputValid(input))
				throw new ArgumentException();

			var filteredInput = input.ToList().Where(_ => !_.StartsWith('-') && !_.StartsWith("--"));
			var length = filteredInput.Count();
			if (length == 0)
				return DateTime.Now;

			if (Int32.TryParse(input[0], out var day))
			{
				if (useJulianDay)
					return new DateTime(DateTime.Now.Year, 1, 1).AddDays(day - 1);

				return new DateTime(
					length > 2 && Int32.TryParse(filteredInput.ElementAt(2), out var year) ? year : DateTime.Now.Year,
					length > 1 && Int32.TryParse(filteredInput.ElementAt(1), out var month) ? month : DateTime.Now.Month,
					day);
			}
			else
				throw new ArgumentException(@"This shouldn't happen if the input has been validated. dayAsString -> {dayAsString}");

		}
	}
}