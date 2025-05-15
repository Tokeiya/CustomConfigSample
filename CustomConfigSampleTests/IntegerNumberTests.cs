using CustomConfigSample;

namespace CustomConfigSampleTests;

public class IntegerNumberTests
{
	[Fact]
	public void CtorTest()
	{
		var fixture = new IntegerNumber(42);
		fixture.Value.Is(42);
	}
}