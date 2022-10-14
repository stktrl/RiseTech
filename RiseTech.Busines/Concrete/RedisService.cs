using Microsoft.Extensions.Configuration;
using RiseTech.Busines.Abstract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.Concrete
{
    public class RedisService : IRedisService
    {
        private IConfiguration _configuration;
        private ConfigurationOptions _configurationOptions;
        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
            _configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { _configuration.GetConnectionString("Redis") },
                AbortOnConnectFail = false,
            };
        }
        public RedisValue ReadRedis(string Key)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase db = redis.GetDatabase(7);
                if (db.KeyExists(Key))
                {
                    return db.StringGet(Key);
                }
            }
            return RedisValue.Null;
        }
        public void WriteRedis(string Key, string Data)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase db = redis.GetDatabase(7);
                TimeSpan timeSpan = new TimeSpan(3, 0, 0);
                db.StringSet(Key, Data, timeSpan);
            }
        }
        public void DeleteRedis(string Key)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase db = redis.GetDatabase(7);
                db.KeyDelete(Key);
            }
        }
        public void ClearRedis()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configurationOptions + ",allowAdmin=true"))
            {
                redis.GetServer(_configuration.GetConnectionString("Redis")).FlushDatabase(7);
            }
        }
    }
}
