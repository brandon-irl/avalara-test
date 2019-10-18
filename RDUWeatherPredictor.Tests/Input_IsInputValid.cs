using System;
using RDUWeatherPredictor.Client;
using Xunit;

namespace RDUWeatherPredictor.Tests
{
	public class Input_IsInputValid
	{
		[Fact]
		public void InputService_InputIsNull_ReturnTrue()
		{
			var result = Utility.IsInputValid(null);
			Assert.True(result, "null should be a valid input");
		}

		[Theory]
		[InlineData("123abc")]
		[InlineData("1.2")]
		[InlineData(">>>????!!!")]
		public void InputService_InputContainsBadChars_ReturnFalse(string input)
		{
			var result = Utility.IsInputValid(new string[] { input });
			Assert.False(result, $"input should be invalid");
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(367)]
		[InlineData(Int32.MaxValue)]
		[InlineData(Int32.MinValue)]
		public void InputService_InputIsOutOfRange_ReturnFalse(int input)
		{
			var result = Utility.IsInputValid(new string[] { input.ToString() });
			Assert.False(result, $"{input} is out of range");
		}
	}
}
