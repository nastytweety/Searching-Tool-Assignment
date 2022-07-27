using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class Ticker
    {
        [Key]
        public int Id { get; set; }
        public string Source { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
    }
}
