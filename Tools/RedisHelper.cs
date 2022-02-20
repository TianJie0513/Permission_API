using Microsoft.Extensions.Configuration;
using System;

namespace Tools
{
    public  class RedisHelper<T>:IRedisHelper<T> where T:class,new()
    {
        private  readonly IConfiguration configuration;
        private ServiceStack.Redis.RedisClient client = null;
        public RedisHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.client = new ServiceStack.Redis.RedisClient(host, port);
         
        }
        private string host { get { return this.configuration.GetSection("host").Value; } }
        private int port { get { return int.Parse(this.configuration.GetSection("port").Value); } }
        /// <summary>
        /// 根据key设置数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="TModels"></param>
      public  void Set(string key,T TModels)
        {
            client.Set<T>(key, TModels);
        }
        //根据key获取数据
        public T Get(string key)
        {
            return client.Get<T>(key);        
        }

    }
}
