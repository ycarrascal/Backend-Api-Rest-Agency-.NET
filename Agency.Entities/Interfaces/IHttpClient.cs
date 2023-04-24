using Microsoft.Extensions.Configuration;

namespace Agency.Entities.Interfaces
{
    public interface IHttpClient
    {
        IConfigurationSection GetSection(string key);
    }
}
