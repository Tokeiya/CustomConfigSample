using Microsoft.Extensions.Configuration;

namespace CustomConfigSample;

public class BootCommandSourceProvider : ConfigurationProvider
{
	private readonly IReadOnlyList<string> _args;

	public BootCommandSourceProvider(IReadOnlyList<string> args) => _args = args;


	public override void Load()
	{
		if (_args.Count == 1)
		{
			Data["StringValue"] = _args[0];
		}
		else if (_args.Count == 2)
		{
			Data["StringValue"] = _args[0];
			Data["IntegerValue"] = _args[1];
		}
	}
}