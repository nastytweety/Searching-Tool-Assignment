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
        public string Name { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string BaseURL { get; set; }
        [Required(ErrorMessage = "Price Keyword is required")]
        public string PriceKeyword { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public string DateTimeKeyword { get; set; }
    }
}
