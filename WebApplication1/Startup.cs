using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Steeltoe.Management.Tracing;
using Steeltoe.Connector.PostgreSql.EFCore;
//using Steeltoe.Management.Endpoint.SpringBootAdminClient;

using WebApplication1.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1 {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddDbContext<TodoContext>(options => options.UseNpgsql(Configuration));
			
			services.AddControllers();

			services.AddDistributedTracing(Configuration, builder => builder.UseZipkinWithTraceOptions(services));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TodoContext context, ILogger<Startup> logger) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			//app.RegisterWithSpringBootAdmin(Configuration);

			logger.LogInformation($"Ensuring database '{context.Database.GetDbConnection().Database}' has been created");
			context.Database.EnsureCreated();
		}
	}
}
