using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Management.Endpoint;
using Steeltoe.Extensions.Logging;

namespace WebApplication1 {
	public class Program {
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();
		}

public static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(webBuilder => {
			webBuilder
				.UseStartup<Startup>();
		})
		.AddAllActuators()
		.AddDynamicLogging()
		;
	}
}
