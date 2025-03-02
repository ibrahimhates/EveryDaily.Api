using EveryDaily.Application.Settings;
using EveryDaily.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EveryDaily.Application.Extensions;

public static class ConfigureExtensions
{
   public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddMemoryCache();
      services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
      services.AddSingleton<IRedisService>(sp =>
      {
         var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;

         var redis = new RedisService(redisSettings.Host, redisSettings.Port);

         var result = redis.Connect();
         return redis;
      });
   }
}