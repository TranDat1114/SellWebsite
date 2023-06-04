using Microsoft.EntityFrameworkCore;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SellWebsite.Utility.IdentityHandler;


namespace SellWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. 
            //.UseLazyLoadingProxies()
            //Test :tên database khác để hỗ trợ việc đổi dữ liệu 
            //DebugDb : tên database khác để hỗ trợ việc đổi dữ liệu 
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DebugDb")));

            //options.SignIn.RequireConfirmedAccount = true Đăng nhập sẽ gửi yêu cầu confirm về email

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //Thêm cấu hình cho cookie và nhớ phải nằm dưới AddIdentity
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();

            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "home",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}