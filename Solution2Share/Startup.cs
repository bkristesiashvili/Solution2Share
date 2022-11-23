using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using Solution2Share.Data;
using Solution2Share.Extensions;
using Solution2Share.Service;

using System.Threading.Tasks;

namespace Solution2Share;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(options =>
            {
                Configuration.Bind("AzureAD", options);

                options.Events.OnAuthenticationFailed = context =>
                {
                    context.Response
                           .Redirect($"/home/error");
                    
                    context.HandleResponse();

                    return Task.FromResult(0);
                };

                options.Events.OnRemoteFailure = context =>
                {
                    if (context.Failure is OpenIdConnectProtocolException)
                    {
                        context.Response
                            .Redirect($"/home/error");
                        context.HandleResponse();
                    }

                    return Task.FromResult(0);
                };
            })
            .EnableTokenAcquisitionToCallDownstreamApi(options =>
            {
                Configuration.Bind("AzureAd", options);
            }, GraphScopes.Scopes)
            .AddMicrosoftGraph(option =>
            {
                option.Scopes = string.Join(' ', GraphScopes.Scopes);
            })
            .AddInMemoryTokenCaches();

        services.AddControllersWithViews()
            .AddMicrosoftIdentityUI();

        services.AddDbContext<Solution2ShareDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("task")
                , migration => migration.MigrationsAssembly("Solution2Share.Data"));
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserService, UserService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRegisterMicrosoftUser(options =>
        {
            options.ErrorHandlerUrl = "/home/error";
            options.RegisterCompletionUrl = "/home/complete";
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
