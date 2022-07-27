using System.ComponentModel.DataAnnotations;

namespace Searching_Tool_Assignment.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseURL { get; set; }
        public string PriceKeyword { get; set; }
        public string DateKeyword { get; set; }
    }
}
