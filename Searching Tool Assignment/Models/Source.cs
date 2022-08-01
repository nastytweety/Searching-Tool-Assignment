using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Source
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseURL { get; set; }
        public string PriceKeyword { get; set; }
        public string DateTimeKeyword { get; set; }
    }
}
