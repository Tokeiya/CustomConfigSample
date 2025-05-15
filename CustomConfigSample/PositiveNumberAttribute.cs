using System.ComponentModel.DataAnnotations;

namespace CustomConfigSample;

public class PositiveNumberAttribute:ValidationAttribute
{
	protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
	{
		var num=value as IntegerNumber;

		
		if (num is null)
		{
			return new ValidationResult("Value must be an integer number");
		}
		
		if (num.Value<0)
		{
			return new ValidationResult("Value must be positive");
		}
		
		return ValidationResult.Success!;
	}
	
}