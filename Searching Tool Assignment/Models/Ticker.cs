using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Ticker
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public string CreatedDate { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }
    }
}
