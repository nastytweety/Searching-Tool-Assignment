using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Source
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Url is required")]
        public string BaseURL { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price Keyword is required")]
        public string PriceKeyword { get; set; } = String.Empty;
        [Required(ErrorMessage = "Date is required")]
        public string DateTimeKeyword { get; set; } = String.Empty;
    }
}
