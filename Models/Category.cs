using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace News.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name    { get; set; }
        [Required]  
        [MinLength(1)]
        [MaxLength(99999)]
        [StringLength(1000)]
        [DisplayName("Category Description")]
        public string Description { get; set; }
    }
}