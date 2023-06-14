
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SellWebsite.Models.Models
{

    [Table("Catagories")]
    public class Category
    {
        [Key]
        [Column("CategoryId", TypeName = "int")]
        [DisplayName("Category ID")]
        public int Id { get; set; }
        [Column("CategoryNameEnglish", TypeName = "varchar(128)")]
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(128)]
        public string NameEnglish { get; set; } = string.Empty;
               
        [Column("CategoryDescriptionEnglish", TypeName = "varchar(2048)")]
        [DisplayName("Category Description")]
        [MaxLength(2048)]
        public string? DescriptionEnglish { get; set; }

        [Column("CategoryNameVietnamese", TypeName = "nvarchar(128)")]
        [DisplayName("Tên danh mục")]
        [Required]
        [MaxLength(128)]
        public string NameVietnamese { get; set; }

        [Column("CategoryDescriptionVietnamese", TypeName = "nvarchar(2048)")]
        [DisplayName("Mô tả danh mục")]
        [MaxLength(2048)]
        public string? DescriptionVietnamese { get; set; }
        [ValidateNever]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
