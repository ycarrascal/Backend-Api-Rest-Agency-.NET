using Agency.Entities.Models;

namespace Agency.Entities.Interfaces
{
    


    public interface IConfig
    {
        Task<HttpResponseMessage> Get(string key, ApiSettings apiSettings);
    }
}
