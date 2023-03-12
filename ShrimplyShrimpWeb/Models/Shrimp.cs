using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShrimplyShrimpWeb.Models
{
    public class Shrimp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
