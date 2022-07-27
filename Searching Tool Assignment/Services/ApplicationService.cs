using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Services
{
    public class ApplicationService : IApplicationService
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public List<Currency> GetCurrencies()
        {
            return new List<Currency>();
        }
        public HttpClient GetHttpClient() 
        { 
            return new HttpClient();
        }
        public Ticker GetTicker(string Response)
        {
            return new Ticker();
        }
    }
}
