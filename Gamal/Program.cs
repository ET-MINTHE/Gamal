using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack;

namespace Gamal
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
                   webBuilder.ConfigureKestrel((context, options) =>
                   {
                      // Handle requests up to 50 MB
                      options.Limits.MaxRequestBodySize = 52428800;
                   })
                   .UseStartup<Startup>();
                });
   }
}
