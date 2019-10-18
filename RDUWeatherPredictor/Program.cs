using System;
using System.Threading.Tasks;
using CommandLine;
using RDUWeatherPredictor.Data;
using RDUWeatherPredictor.Services;

namespace RDUWeatherPredictor.Client
{
	class Program
	{
		public static void Main(string[] args)
		{
			Parser.Default.ParseArguments<CLOptions>(args)
				.WithParsed<CLOptions>(options =>
				{
					try
					{

						var date = Utility.TranslateInput(args, options.UseJulianDay);

						using (var context = new ConsoleWeatherDbContext())
						{
							var dailyNormalRepo = new DailyNormalRepository(context);
							var dailyNormalDataService = new DailyNormalService(dailyNormalRepo);
							var predictionService = Utility.GetPredictionService(options.Predictor, dailyNormalDataService);


							Console.WriteLine($"Calculating weather prediction for {date.ToShortDateString()}...");
							if (options.TakeClimateIntoAccount)
								Console.WriteLine("...taking climate change into account...");
							var result = predictionService.Predict(date.DayOfYear, options.TakeClimateIntoAccount).Result;
							Console.WriteLine("Here is your result: ");
							Console.WriteLine(result.ToString());
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Error occurred.");
						Console.WriteLine(e.Message);
					}
					finally
					{
						Console.WriteLine();
						Console.ReadKey();
					}
				});
		}
	}
}
