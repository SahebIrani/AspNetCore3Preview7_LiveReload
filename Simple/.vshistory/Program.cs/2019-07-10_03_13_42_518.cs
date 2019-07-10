using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace Simple
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)

				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureKestrel(options =>
					{
						// allow for Http2 support - make sure use Http1AndHttp2!
						options.ConfigureEndpointDefaults(c => c.Protocols = HttpProtocols.Http1AndHttp2);
					})
					.UseStartup<Startup>();
				});
	}
}
