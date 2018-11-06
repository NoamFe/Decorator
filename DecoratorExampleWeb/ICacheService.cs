using System;
using System.Threading.Tasks;

namespace DecoratorExampleWeb
{
    public interface ICacheService
    {
        Task<bool> Add(string key, object value);
        
        Task<T> Get<T>(string key);
        
        Task<bool> Remove(string key);
    }
}