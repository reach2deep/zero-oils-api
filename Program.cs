using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Verdant.Zero.Erp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        //public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        //   WebHost.CreateDefaultBuilder(args)
        //       .UseStartup<Startup>()
        //        .UseKestrel((context, options) =>
        //        {
        //            var port = Environment.GetEnvironmentVariable("PORT");

        //            if (!string.IsNullOrEmpty(port))
        //            {
        //                options.ListenAnyIP(int.Parse(port));
        //            }
        //        });


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) 
        {
            var port = Environment.GetEnvironmentVariable("PORT");

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:" + port);
        }
    }
}
