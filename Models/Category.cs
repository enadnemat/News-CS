using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace News.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name    { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}