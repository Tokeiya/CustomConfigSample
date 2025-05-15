using System.ComponentModel.DataAnnotations;

namespace CustomConfigSample;

public class BootArgs
{
	[Required] public required string StringValue { get; init; }
	[PositiveNumber] public IntegerNumber IntegerValue { get; init; } = new(42);
}