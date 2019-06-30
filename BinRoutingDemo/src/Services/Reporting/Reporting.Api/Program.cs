using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Reporting.Api
{
    public class Program
    {
        public static string IP;
        public static int Port;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            IP = config["ip"];
            Port = Convert.ToInt32(config["port"]);

            if (string.IsNullOrEmpty(IP))
            {
                IP = NetworkHelper.LocalIPAddress;
            }

            if (Port == 0)
            {
                Port = NetworkHelper.GetRandomAvaliablePort();
            }

            return WebHost.CreateDefaultBuilder(args)
                            .UseStartup<Startup>()
                            .UseUrls($"http://{IP}:{Port}")
                            .Build();
        }
    }
}


