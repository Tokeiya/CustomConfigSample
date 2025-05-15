//At first register the custom type converter.

using System.ComponentModel;
using CustomConfigSample;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


//At first register the custom type converter.
TypeDescriptor.AddAttributes(typeof(IntegerNumber), new TypeConverterAttribute(typeof(IntegerNumberConverter)));

var builder = Host.CreateDefaultBuilder(args)
	.ConfigureHostConfiguration(conf =>
	{
		var tmp = conf.Sources.OfType<CommandLineConfigurationSource>().FirstOrDefault();
		if (tmp is not null) conf.Sources.Remove(tmp);

		conf.Add(new BootCommandConfigurationSource(args));
	}).ConfigureServices((ctx, services) =>
	{
		services.AddOptions<BootArgs>()
			.Bind(ctx.Configuration)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		services.AddHostedService<SampleHost>();
	});

builder.Build().Run();


public class SampleHost : IHostedService
{
	private readonly IOptions<BootArgs> _args;
	private readonly IHostApplicationLifetime _lifetime;
	private readonly ILogger<SampleHost> _logger;

	public SampleHost(IOptions<BootArgs> args, ILogger<SampleHost> logger, IHostApplicationLifetime lifetime)
	{
		logger.LogInformation("SampleHost ctor called");
		_args = args;
		_logger = logger;
		_lifetime = lifetime;

		logger.LogInformation("SampleHost ctor exit");
	}

	public Task StartAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("SampleHost StartAsync called");
		_logger.LogInformation($"StringValue: {_args.Value.StringValue}");
		_logger.LogInformation($"IntegerValue: {_args.Value.IntegerValue.Value}");

		_lifetime.StopApplication();

		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}