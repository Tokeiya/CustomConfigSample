// See https://aka.ms/new-console-template for more information

using GracefulShutdownSample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var options=new HostedServiceOptions(TimeSpan.FromSeconds(5),TimeSpan.FromSeconds(1));

var host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((ctx, srv) =>
	{
		srv.Configure<HostOptions>(opt =>
		{
			opt.ShutdownTimeout = TimeSpan.FromSeconds(10);
		});

		srv.AddSingleton<IHostedServiceOptions>(options);
		srv.AddHostedService<StopAsyncSample>();

	});

host.Build().Run();

Console.WriteLine("Hello, World!");