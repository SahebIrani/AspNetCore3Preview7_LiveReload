using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Westwind.AspNetCore.LiveReload;

namespace Simple
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLiveReload(config =>
			{
				// optional - use config instead
				config.LiveReloadEnabled = true;
				//config.FolderToMonitor = Env.ContentRootPath;
				//config.FolderToMonitor = Path.GetFullname(Path.Combine(Environment.ContentRootPath, ".."));
			});

			//services.AddControllersWithViews()
			//	.AddMvcOptions(opt => { opt.SerializerOptions.PropertyNameCaseInsensitive = true; })
			//;
			//.AddNewtonsoftJson();

			// for ASP.NET Core 3.0 add Runtime Razor Compilation
			// Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddRazorRuntimeCompilation();
			services.AddRazorPages().AddRazorRuntimeCompilation();

			//dotnet dev-certs https--clean
			//dotnet dev - certs https--trust

			//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			//services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				// add it here
				//app.UseLiveReload();

				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			//dotnet watch run
			// Before any other output generating middleware handlers
			app.UseLiveReload();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
