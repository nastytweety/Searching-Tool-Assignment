using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Searching_Tool_Assignment.Models
{
    public class Currency
    {
        [Key]
        [JsonIgnore]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string CurrencyName { get; set; }
        [Required(ErrorMessage = "Extension is required")]
        public string Extension { get; set; }
    }
}
