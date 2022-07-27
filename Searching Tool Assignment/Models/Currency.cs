using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string Extension { get; set; }
    }
}
