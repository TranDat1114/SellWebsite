
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public string NameEnglish { get; set; }

        [Column("CategoryImage", TypeName = "varchar(256)")]
        [DisplayName("Category Image Url")]
        [Required]
        [MaxLength(256)]
        public string Image { get; set; }

        [Column("CategoryDescriptionEnglish", TypeName = "varchar(512)")]
        [DisplayName("Category Description")]
        [MaxLength(512)]
        public string? DescriptionEnglish { get; set; }

        [Column("CategoryNameVietnamese", TypeName = "nvarchar(128)")]
        [DisplayName("Tên danh mục")]
        [Required]
        [MaxLength(128)]
        public string NameVietnamese { get; set; }

        [Column("CategoryDescriptionVietnamese", TypeName = "nvarchar(512)")]
        [DisplayName("Mô tả danh mục")]
        [MaxLength(512)]
        public string? DescriptionVietnamese { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
