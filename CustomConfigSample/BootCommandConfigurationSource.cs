using Microsoft.Extensions.Configuration;

namespace CustomConfigSample;

public class BootCommandConfigurationSource : IConfigurationSource
{
	private readonly IReadOnlyList<string> _args;

	public BootCommandConfigurationSource(IReadOnlyList<string> args) => _args = args;

	public IConfigurationProvider Build(IConfigurationBuilder builder) => new BootCommandSourceProvider(_args);
}