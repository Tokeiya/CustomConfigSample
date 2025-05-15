using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace CustomConfigSample;

[TypeConverter(typeof(IntegerNumberConverter))]
public record IntegerNumber(int Value);

public class IntegerNumberConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
		=> destinationType == typeof(string);

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		var str=value as string;

		if (str is null)
		{
			throw new NotSupportedException($"{nameof(value)} must be a string type");
		}
		
		return new  IntegerNumber(int.Parse(str));
	}
}