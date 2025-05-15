using CustomConfigSample;

namespace CustomConfigSampleTests;

public class IntegerNumberConverterTests
{
	[Fact]
	public void CanConvertTest()
	{
		var fixture = new IntegerNumberConverter();
		fixture.CanConvertTo(null, typeof(string)).IsTrue();
		fixture.CanConvertTo(null, typeof(int)).IsFalse();
	}

	[Fact]
	public void ConvertFromTests()
	{
		var fixture=new IntegerNumberConverter();
		fixture.ConvertFrom(null, null, "42").Is(new IntegerNumber(42));

		Assert.Throws<NotSupportedException>(() => fixture.ConvertFrom(null, null, 42));
		Assert.Throws<FormatException>(() => fixture.ConvertFrom(null, null, "a"));
	}
}