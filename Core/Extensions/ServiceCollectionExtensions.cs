﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollections, ICoreModule[] modules)
        {
            foreach (var module in modules)
        	{
                module.Load(serviceCollections);

	        }
            return ServiceTool.Create(serviceCollections);
        }
    }
}
