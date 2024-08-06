using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gear.Infrastructure.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gear.WebApi.Plataform.Extensions
{
    public static class Extensions
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var mappingConfig = Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void RegisterDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyInjector.RegisterDependencyInjection(services, configuration);
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
