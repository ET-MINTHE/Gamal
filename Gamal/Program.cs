using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack;
using Amazon.Extensions.Configuration.SystemsManager;

namespace Gamal
{
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateWebHostBuilder(args).Build().Run();
        }

		public static IHostBuilder CreateWebHostBuilder(string[] args) =>
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

		//public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		//  WebHost.CreateDefaultBuilder(args)
		//  .ConfigureAppConfiguration(builder =>
		//  {
		//    // builder.AddSystemsManager("/GamalApp/dev/constrdf");
		//  })
		//  .UseStartup<Startup>();
	}
}
