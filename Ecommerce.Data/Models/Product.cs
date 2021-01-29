using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
       
        [Range(0,double.MaxValue)]
        public double UnitPrice { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [Required]
        public Category Category{ get; set; }

    }
}
