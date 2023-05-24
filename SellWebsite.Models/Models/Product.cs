using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWebsite.Models.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductId", TypeName = "int")]
        [DisplayName("Product ID")]
        public int Id { get; set; }

        [Required]
        [Column("ProductTitle", TypeName = "nvarchar(128)")]
        [DisplayName("Product Title")]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [Column("ProductAuthor", TypeName = "nvarchar(128)")]
        [DisplayName("Product Author")]
        [MaxLength(128)]
        public string Author { get; set; }

        [Column("ProductDescription", TypeName = "nvarchar(4096)")]
        [MaxLength(4096)]
        [DisplayName("Product Description")]
        public string? Description { get; set; }

        [Column("ProductCreatedDate", TypeName = "Date")]
        [DisplayName("Created Date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("ProductUpdatedDate", TypeName = "Date")]
        [DisplayName("Updated Date")]

        public DateTime UpdatedDate { get; set; }

        [Column("ProductLicense", TypeName = "varchar(128)")]
        [MaxLength(128)]
        public string? License { get; set; }

        [Column("ProductCredits", TypeName = "varchar(256)")]
        [MaxLength(256)]
        [DisplayName("Product Credits")]
        public string? Credits { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("ProductPreviewUrl", TypeName = "varchar(128)")]
        [DisplayName("Preview Url")]
        public string PreviewUrl { get; set; }

        [Required]
        [Column("ProductDownloadCount", TypeName = "int")]
        [DisplayName("Download Count")]
        public int DownloadCount { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("ProductDownloadUrl", TypeName = "varchar(128)")]
        [DisplayName("Download Url")]
        public string DownloadUrl { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("ProductPostsBy", TypeName = "varchar(128)")]
        [DisplayName("PostsBy")]
        public string PostsBy { get; set; }

        [Column("ProductImage", TypeName = "varchar(256)")]
        [DisplayName("Product Image Url")]
                [MaxLength(256)]
        
        public string? Image { get; set; }


        [DisplayName("Categories")]
        public virtual ICollection<Category>? Categories { get; set; }

    }
}
