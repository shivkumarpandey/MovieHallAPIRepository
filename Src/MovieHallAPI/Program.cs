using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHallAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             
              .ConfigureAppConfiguration((hostContext, builder) =>
                     {
                         builder.AddJsonFile("Serilog.json");
                         builder.AddJsonFile("appsettings.json");
                     })
                    .ConfigureLogging((hostContext, builder) =>
                    {
                        Log.Logger = new LoggerConfiguration()
                                         .ReadFrom.Configuration(hostContext.Configuration)
                                         .Enrich.FromLogContext()
                                         .CreateLogger();
                        builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                        builder.AddSerilog(dispose: true);
                    }).UseSerilog().UseStartup<Startup>();

    }
}
