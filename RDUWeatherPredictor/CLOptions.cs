using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace RDUWeatherPredictor.Client
{
	internal class CLOptions
	{
		[Option('j', "julian", Required = false, HelpText = "Treat day input as the day of the year. Month and year will not be considered")]
		public bool UseJulianDay { get; set; }

		[Option('c', "climate-change", Required = false, HelpText = "Include chinese hoaxes in predictions")]
		public bool TakeClimateIntoAccount { get; set; }

		[Option('p', "predictor", Required = false, Default = "dumb", HelpText = "Determines which prediction model is used")]
		public string Predictor { get; set; }
	}
}