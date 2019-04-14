using Microsoft.Extensions.DependencyInjection;

namespace Convey.Persistence.Redis
{
    public static class Extensions
    {
        private const string SectionName = "redis";

        public static IConveyBuilder AddRedis(this IConveyBuilder builder, string sectionName = SectionName)
        {
            var options = builder.GetOptions<RedisOptions>(sectionName);
            return builder.AddRedis(options);
        }
        
        public static IConveyBuilder AddRedis(this IConveyBuilder builder, RedisOptions options)
        {
            builder.Services.AddDistributedRedisCache(o => 
            {
                o.Configuration = options.ConnectionString;
                o.InstanceName = options.Instance;
            });

            return builder;
        }
    }
}