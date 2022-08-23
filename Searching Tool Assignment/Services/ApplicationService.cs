using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Searching_Tool_Assignment.Models;
using System.Net.Http.Headers;

namespace Searching_Tool_Assignment.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string UnixTimeStampToDateTime(double UnixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(UnixTimeStamp).ToLocalTime();
            return dateTime.ToShortDateString();
        }
        public HttpClient GetHttpClient(string BaseUrl) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public Ticker GetTicker(JObject Obj,Source source,string CurrencyName)
        {
            Ticker ticker = new Ticker();
            double price = Convert.ToDouble(Obj.SelectToken(source.PriceKeyword));
            double timestamp = Convert.ToDouble(Obj.SelectToken(source.DateTimeKeyword));
            price = Math.Round(price, 2);
            string windowstime = UnixTimeStampToDateTime(timestamp);
            ticker.Source = source.Name;
            ticker.Currency = CurrencyName;
            ticker.Price = price.ToString();
            ticker.CreatedDate = windowstime;
            return ticker;
        }
    }
}
