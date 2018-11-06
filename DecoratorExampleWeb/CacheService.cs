using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecoratorExampleWeb
{
    public class CacheService : ICacheService
    {
        Dictionary<string,object> _dictionary = new Dictionary<string, object>();

        public Task<bool> Add(string key, object value)
        {
            _dictionary.Add(key,value);
            return Task.FromResult(true);
        }

        public Task<T> Get<T>(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                return Task.FromResult((T)_dictionary[key]);
            }

            return Task.FromResult(default(T));
        }


        public async Task<T> Geta<T>(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                return (T)_dictionary[key];
            }

            return default(T);
        }

        public Task<bool> Remove(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key] = null;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        } 
    }
}