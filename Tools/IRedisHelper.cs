using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
   public interface IRedisHelper<T> where T:class,new()
    {
        void Set(string key, T TModels);
        T Get(string key);
    }
}
