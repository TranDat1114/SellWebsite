using Microsoft.EntityFrameworkCore;

using SellWebsite.DataAccess.Data;
using SellWebsite.DataAccess.Reponsitory;
using SellWebsite.DataAccess.Reponsitory.IReponsitory;

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
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Test")));


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "home",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}