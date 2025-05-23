namespace GracefulShutdownSample;

public interface IHostedServiceOptions
{
	TimeSpan Delay { get; }
	TimeSpan LoggingInterval { get; }
}

public record HostedServiceOptions(TimeSpan Delay, TimeSpan LoggingInterval) : IHostedServiceOptions;