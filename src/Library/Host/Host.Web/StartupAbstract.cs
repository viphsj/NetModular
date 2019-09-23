﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nm.Lib.Host.Web.Options;
using Nm.Lib.Utils.Core.Helpers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Nm.Lib.Host.Web
{
    public abstract class StartupAbstract
    {
        protected readonly HostOptions HostOptions;
        protected readonly IHostingEnvironment Env;

        protected StartupAbstract(IHostingEnvironment env)
        {
            Env = env;
            var cfgHelper = new ConfigurationHelper();
            //加载主机配置项
            HostOptions = cfgHelper.Get<HostOptions>("Host", env.EnvironmentName) ?? new HostOptions();
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebHost(HostOptions, Env);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseWebHost(HostOptions, Env);

            app.UseShutdownHandler();
        }
    }
}
