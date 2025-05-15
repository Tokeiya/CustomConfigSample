using CustomConfigSample;

namespace CustomConfigSampleTests;

public class BootCommandSourceProviderTest
{
	[Fact]
	public void SingleArgTest()
	{
		var fixture = new BootCommandSourceProvider(["foo"]);

		if (fixture.TryGet("StringValue", out var value)) value.Is("foo");
	}

	[Fact]
	public void TwoArgsTest()
	{
		var fixture = new BootCommandSourceProvider(["foo", "42"]);

		if (fixture.TryGet("StringValue", out var value)) value.Is("foo");
		if (fixture.TryGet("IntegerValue", out value)) value.Is("42");
	}

	[Fact]
	public void RedundantArgsTest()
	{
		var fixture = new BootCommandSourceProvider(["hoge", "42", "bar"]);
		if (fixture.TryGet("StringValue", out var value)) value.Is("hoge");
		if (fixture.TryGet("IntegerValue", out value)) value.Is("42");
	}
}