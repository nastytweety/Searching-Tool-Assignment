using Newtonsoft.Json.Linq;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Services
{
    public interface IApplicationService
    {
        public string UnixTimeStampToDateTime(double UnixTimeStamp);
        public HttpClient GetHttpClient(string BaseUrl);
        public Ticker GetTicker(JObject Obj, Source source, string CurrencyName);
    }
}
