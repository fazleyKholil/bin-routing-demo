using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Api
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, ConsulConfiguration consulConfig)
        {
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{consulConfig.ConsulIP}:{consulConfig.ConsulPort}"));
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                HTTP = $"http://{consulConfig.IP}:{consulConfig.Port}/api/health",
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = consulConfig.ServiceName,
                Address = consulConfig.IP,
                Port = consulConfig.Port,
                Tags = new[] { $"urlprefix-/{consulConfig.ServiceName}" }
            };

            consulClient.Agent.ServiceRegister(registration).Wait();
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }

    public class ConsulConfiguration
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string ServiceName { get; set; }
        public string ConsulIP { get; set; }
        public int ConsulPort { get; set; }
    }

}
