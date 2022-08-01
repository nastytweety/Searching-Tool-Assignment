using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Currency
    {
        [Key]
        [JsonIgnore]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string Extension { get; set; }
    }
}
