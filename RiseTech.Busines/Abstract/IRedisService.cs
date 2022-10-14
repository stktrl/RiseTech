using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.Abstract
{
    public interface IRedisService
    {
        RedisValue ReadRedis(string key);
        void WriteRedis(string key, string value);
        void DeleteRedis(string key);
        void ClearRedis();
    }
}
