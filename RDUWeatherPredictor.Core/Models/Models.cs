using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RDUWeatherPredictor
{

	public class DailyNormal
	{
		[Key]
		public int JulianDay { get; set; }
		public string Month { get; set; }
		public int DayOfMonth { get; set; }
		public float NormalMaxTempF { get; set; }
		public float NormalMinTempF { get; set; }
		public float? NormalPrecipitation { get; set; }

		public override string ToString() => $"{JulianDay} | {Month} | {DayOfMonth} | {NormalMaxTempF} | {NormalMinTempF} | {NormalPrecipitation}";
	}

	public interface IPrediction
	{
		float TemperatureF { get; set; }
		float? Precipitation { get; set; }
	}

	[DataContract]
	public class SimplePrediction : IPrediction
	{
		[DataMember]
		public float TemperatureF { get; set; }
		[DataMember]
		public float? Precipitation { get; set; }

		public SimplePrediction(float temperatureF, float? precipitation)
		{
			this.TemperatureF = temperatureF;
			this.Precipitation = precipitation;
		}

		public string ToJson()
		{
			var ser = new DataContractJsonSerializer(typeof(SimplePrediction));
			var stream = new MemoryStream();
			ser.WriteObject(stream, this);
			stream.Position = 0;
			return (new StreamReader(stream).ReadToEnd());
		}

		public override string ToString() => this.ToJson(); // $"{TemperatureF}F 🔥 | {(Precipitation != null ? Precipitation.ToString() : "NA")} 🌧";
	}
}