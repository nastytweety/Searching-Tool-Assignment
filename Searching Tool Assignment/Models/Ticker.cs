using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Ticker
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Source { get; set; }
        public string CreatedDate { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
    }
}
