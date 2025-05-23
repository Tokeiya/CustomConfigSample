using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GracefulShutdownSample;

public class StopAsyncSample:IHostedService
{
	private readonly ILogger _logger;
	private readonly IHostedServiceOptions _options;
	
	
	public StopAsyncSample(ILogger<StopAsyncSample> logger, IHostedServiceOptions options)
	{
		_logger = logger;
		_options = options;
	}

	private void WriteInfomation(string value)
	{
		_logger.LogInformation($"""
		                        Time:{DateTimeOffset.Now}
		                        Message:{value}
		                        
		                        """);
	}

	public Task StartAsync(CancellationToken cancellationToken)
	{
		WriteInfomation("Started");
		return Task.CompletedTask;
	}

	public async Task StopAsync(CancellationToken cancellationToken)
	{
		var chrono = new Stopwatch();
		chrono.Restart();

		while (chrono.Elapsed <= _options.Delay)
		{
			_logger.LogInformation($"""
			                        Elapsed:{chrono.Elapsed}
			                        Token:{cancellationToken.IsCancellationRequested}
			                        """);
			
			await Task.Delay(1000, cancellationToken);
		}
		
		
	}
}