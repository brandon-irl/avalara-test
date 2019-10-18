using System;
using RDUWeatherPredictor.Client;
using Xunit;

namespace RDUWeatherPredictor.Tests
{
	public class Input_TranslateInput
	{

		[Fact]
		public void InputService_DayMonthYearSpecified_ReturnsTrue()
		{
			var input = new string[] { 27.ToString(), 6.ToString(), 1991.ToString() };
			var date = Utility.TranslateInput(input).ToShortDateString();
			var result = date == new DateTime(1991, 6, 27).ToShortDateString();
			Assert.True(result, $"Dates should be equal. -> {date}");
		}

		[Fact]
		public void InputService_DayAndMonthSpecified_ReturnsTrue()
		{
			var input = new string[] { 27.ToString(), 6.ToString() };
			var date = Utility.TranslateInput(input).ToShortDateString();
			var result = date == new DateTime(DateTime.Now.Year, 6, 27).ToShortDateString();
			Assert.True(result, $"Dates should be equal. -> {date}");
		}

		[Fact]
		public void InputService_IsJulianValueSpecified()
		{
			var input = new string[] { 321.ToString() };
			var date = Utility.TranslateInput(input, true).ToShortDateString();
			var result = date == new DateTime(DateTime.Now.Year, 11, 17).ToShortDateString();   // +1 to account for leap year
			Assert.True(result, $"Dates should be equal. -> {date}");
		}

		[Fact]
		public void InputService_ValueIsTomorrow_ReturnsTomorrowDate()
		{
			var input = new string[] { (DateTime.Now.Day + 1).ToString() };
			var result = Utility.TranslateInput(input).ToShortDateString() == DateTime.Now.AddDays(1).ToShortDateString();
			Assert.True(result, "Days should be equal");
		}
	}
}