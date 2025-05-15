using System.ComponentModel.DataAnnotations;
using CustomConfigSample;

namespace CustomConfigSampleTests;

file class Sample
{
	[Required]
	[PositiveNumber]
	public required IntegerNumber  Value {get;init;}
}

public class PositiveNumberAttributeTests
{
	[Fact]
	public void AnnotationTest()
	{
		var value = new Sample { Value = new IntegerNumber(42) };
		var context = new ValidationContext(value);
		var results = new List<ValidationResult>();
		Validator.TryValidateObject(value, context, results, true);
		results.Count.Is(0);
	}

	[Fact]
	public void FailTest()
	{
		var value = new Sample { Value = new(-42) };
		var context = new ValidationContext(value);
		var results = new List<ValidationResult>();
		Validator.TryValidateObject(value, context, results, true);
		results.Count.Is(1);
		results[0].ErrorMessage.Is("Value must be positive");
	}
}