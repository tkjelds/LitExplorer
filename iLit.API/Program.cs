using iLit.API;
using iLit.Core;
using iLit.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
/*using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iLit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var hostBuilder = CreateHostBuilder(args).Build();

            //hostBuilder.Seed(); //<- from our seed extension class. 

            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //configureappconfiguration - to expose/use secrets from folder/text file in linux. optional on windows?
    }
}*/
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddKeyPerFile("/run/secrets", optional: true);

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ILit.API", Version = "v1" });
    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddDbContext<iLitContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("iLit")));
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<IEdgeRepository, EdgeRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

/*if (!app.Environment.IsEnvironment("Integration")) {
    await app.SeedAsync();
}*/

app.Run();

public partial class Program { }
/*
services.AddScoped<IiLitContext, iLitContext>();
services.AddScoped<INodeRepository, NodeRepository>();
services.AddScoped<IEdgeRepository, EdgeRepository>();*/
