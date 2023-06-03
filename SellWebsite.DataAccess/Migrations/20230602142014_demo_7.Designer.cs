﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SellWebsite.DataAccess.Data;

#nullable disable

namespace SellWebsite.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602142014_demo_7")]
    partial class demo_7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SellWebsite.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescriptionEnglish")
                        .HasMaxLength(2048)
                        .HasColumnType("varchar(2048)")
                        .HasColumnName("CategoryDescriptionEnglish");

                    b.Property<string>("DescriptionVietnamese")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasColumnName("CategoryDescriptionVietnamese");

                    b.Property<string>("Image")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("CategoryImage")
                        .HasDefaultValueSql("'/assets/avatar.jpg'");

                    b.Property<string>("NameEnglish")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("CategoryNameEnglish");

                    b.Property<string>("NameVietnamese")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("CategoryNameVietnamese");

                    b.HasKey("Id");

                    b.ToTable("Catagories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DescriptionEnglish = "Nước uống có gas cực ngon",
                            DescriptionVietnamese = "",
                            Image = "no Img",
                            NameEnglish = "Thử nghiệm 2",
                            NameVietnamese = ""
                        },
                        new
                        {
                            Id = 2,
                            DescriptionEnglish = "Nước uống có gas cực ngon",
                            Image = "no Img",
                            NameEnglish = "Thử nghiệm 1",
                            NameVietnamese = ""
                        },
                        new
                        {
                            Id = 3,
                            DescriptionEnglish = "These are websites that provide information on a specific topic, such as news websites, educational websites, or government websites.",
                            DescriptionVietnamese = "Đây là trang web cung cấp thông tin về một chủ đề cụ thể, chẳng hạn như trang web tin tức, trang web giáo dục hoặc trang web chính phủ.",
                            Image = "no Img",
                            NameEnglish = "Informational",
                            NameVietnamese = "Thông tin"
                        },
                        new
                        {
                            Id = 4,
                            DescriptionEnglish = "These are websites that allow users to purchase items online, such as online shopping websites or auction websites.",
                            DescriptionVietnamese = "Đây là trang web cho phép người dùng mua hàng trực tuyến, chẳng hạn như trang web bán hàng trực tuyến hay trang web đấu giá.",
                            Image = "no Img",
                            NameEnglish = "E-commerce",
                            NameVietnamese = "Thương mại điện tử"
                        },
                        new
                        {
                            Id = 5,
                            DescriptionEnglish = "These are websites that provide entertainment content, such as movie streaming websites, gaming websites, or music streaming websites.",
                            DescriptionVietnamese = "Đây là trang web cung cấp các nội dung giải trí, chẳng hạn như trang web xem phim, trang web chơi game hoặc trang web nghe nhạc.",
                            Image = "no Img",
                            NameEnglish = "Entertainment",
                            NameVietnamese = "Giải trí"
                        },
                        new
                        {
                            Id = 6,
                            DescriptionEnglish = "These are websites that allow users to interact and connect with each other, such as Facebook, Twitter, or Instagram.",
                            DescriptionVietnamese = "Đây là trang web cho phép người dùng tương tác và kết nối với nhau, chẳng hạn như Facebook, Twitter, Instagram.",
                            Image = "no Img",
                            NameEnglish = "Social-media",
                            NameVietnamese = "Mạng xã hội"
                        },
                        new
                        {
                            Id = 7,
                            DescriptionEnglish = "These are personal or business websites that provide the latest posts and information on a specific topic.",
                            DescriptionVietnamese = "Đây là trang web cá nhân hoặc doanh nghiệp cung cấp các bài viết và thông tin mới nhất về chủ đề cụ thể.",
                            Image = "no Img",
                            NameEnglish = "Blog",
                            NameVietnamese = "Blog"
                        },
                        new
                        {
                            Id = 8,
                            DescriptionEnglish = "These are websites that allow users to discuss a specific topic and share their opinions with others.",
                            DescriptionVietnamese = "Đây là trang web cho phép người dùng thảo luận về một chủ đề cụ thể và chia sẻ ý kiến của mình với những người khác.",
                            Image = "no Img",
                            NameEnglish = "Forum",
                            NameVietnamese = "Diễn đàn"
                        },
                        new
                        {
                            Id = 9,
                            DescriptionEnglish = "These are websites that provide online tools or services for users, such as Google, Dropbox, or GitHub.",
                            DescriptionVietnamese = "Đây là trang web cung cấp các công cụ hoặc dịch vụ trực tuyến cho người dùng, chẳng hạn như Google, Dropbox hay GitHub.",
                            Image = "no Img",
                            NameEnglish = "Tool",
                            NameVietnamese = "Công cụ"
                        },
                        new
                        {
                            Id = 10,
                            DescriptionEnglish = "These are websites that provide online courses or study materials, such as Coursera, edX, or Udemy.",
                            DescriptionVietnamese = "Đây là trang web cung cấp các khóa học hoặc tài liệu học tập trực tuyến, chẳng hạn như Coursera, edX hay Udemy.",
                            Image = "no Img",
                            NameEnglish = "Online-learning",
                            NameVietnamese = "Học tập trực tuyến"
                        },
                        new
                        {
                            Id = 11,
                            DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                            DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                            Image = "no Img",
                            NameEnglish = "Food",
                            NameVietnamese = "Ẩm thực"
                        },
                        new
                        {
                            Id = 12,
                            DescriptionEnglish = "Phòng trưng bày",
                            DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                            Image = "no Img",
                            NameEnglish = "Exhibition",
                            NameVietnamese = "Trưng bày"
                        },
                        new
                        {
                            Id = 14,
                            DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                            DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                            Image = "no Img",
                            NameEnglish = "Travel",
                            NameVietnamese = "Du lịch"
                        },
                        new
                        {
                            Id = 15,
                            DescriptionEnglish = "I'm too lazy to write it down, I can't edit it anymore",
                            DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                            Image = "no Img",
                            NameEnglish = "Sports",
                            NameVietnamese = "Thể thao"
                        },
                        new
                        {
                            Id = 16,
                            DescriptionEnglish = "A huge list of the best business website templates is built to serve any company, from construction to business consulting and financial services. All templates are mobile-friendly and feature both one-page and multi-page setups. Whether you are bringing a fresh project or redesigning your current website, these templates have you covered. They are powerful enough to meet any firm and organization owner’s needs and requirements.",
                            DescriptionVietnamese = "Lười quá hông có ghi nữa, nào hết lười sửa lại",
                            Image = "/assets/dev.png",
                            NameEnglish = "Business",
                            NameVietnamese = "Kinh doanh"
                        });
                });

            modelBuilder.Entity("SellWebsite.Models.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SellWebsite.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("ProductAuthor");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasColumnName("ProductCreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Credits")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("ProductCredits")
                        .HasDefaultValueSql("'JADY'");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasColumnName("ProductDescription");

                    b.Property<int>("DownloadCount")
                        .HasColumnType("int")
                        .HasColumnName("ProductDownloadCount");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ProductDownloadUrl");

                    b.Property<string>("Image")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("ProductImage")
                        .HasDefaultValueSql("'/assets/dev.png'");

                    b.Property<string>("License")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ProductLicense");

                    b.Property<string>("PostsBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ProductPostsBy");

                    b.Property<string>("PreviewUrl")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("ProductPreviewUrl");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ProductPrice")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("ProductTitle");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasColumnName("ProductUpdatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "TranPhuDat",
                            CreatedDate = new DateTime(2023, 6, 2, 21, 20, 14, 157, DateTimeKind.Local).AddTicks(1381),
                            Credits = "Images from Unsplash;Boostrap",
                            Description = "Glint is a modern and stylish digital agency HTML template. Designed for creative designers, agencies, freelancers, photographers, or any creative profession.",
                            DownloadCount = 0,
                            DownloadUrl = "linkdownloadFIle",
                            License = "",
                            PostsBy = "ADminTPD",
                            PreviewUrl = "LinkPreviewUrl",
                            Price = 500000m,
                            Title = "Glint",
                            UpdatedDate = new DateTime(2023, 6, 2, 21, 20, 14, 157, DateTimeKind.Local).AddTicks(1399)
                        });
                });

            modelBuilder.Entity("SellWebsite.Models.Models.ShoppingCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("SellWebsite.Models.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("SellWebsite.Models.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SellWebsite.Models.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SellWebsite.Models.Models.ShoppingCart", b =>
                {
                    b.HasOne("SellWebsite.Models.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SellWebsite.Models.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
