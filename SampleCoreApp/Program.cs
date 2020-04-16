using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleCoreApp
{
    using System.Net;
    using Microsoft.AspNetCore.Server.Kestrel.Core;

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
                    webBuilder
                        .ConfigureKestrel(serverOptions =>
                        {
                            serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                            serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);

                            serverOptions.Limits.MaxConcurrentConnections = 100;
                            serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;

                            serverOptions.Limits.MinRequestBodyDataRate =
                                new MinDataRate(100, TimeSpan.FromSeconds(10));
                            serverOptions.Limits.MinResponseDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));

                            serverOptions.DisableStringReuse = true;

                            serverOptions.Listen(IPAddress.Loopback, 5000);
                            // serverOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
                            // {
                            //     listenOptions.UseHttps("testCert.pfx", 
                            //         "testPassword");
                            // });
                        }).UseStartup<Startup>();
                });
    }
}