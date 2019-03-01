using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Plugin.Misc.CustomToken.Infrastructure
{
    class DependancyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        /// <summary>
        /// Register services and interfaces
        /// see: https://www.nopcommerce.com/boards/t/14959/how-to-add-new-message-tokens-to-be-used-in-message-templates.aspx
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            // register Message Token Provider
            // allows custom class to add custom tokens 
            // for use with email message templates
            builder.RegisterType<CustomMessageTokenProvider>().As<IMessageTokenProvider>().InstancePerDependency();

        }
    }
}
