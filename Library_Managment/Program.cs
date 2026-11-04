using Library_Managment.BLL.Services;
using Library_Managment.DAL.Context;
using Library_Managment.DAL.Data;
using Library_Managment.PL.MappingProfiles;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Library_ManagmentDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    );
            });
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<IMemberRepository,MemberRepository>();
            builder.Services.AddScoped<IBorrowRepository,BorrowRepository>();

            builder.Services.AddAutoMapper(M => M.AddProfile(new BookProfile()));
            builder.Services.AddAutoMapper(M => M.AddProfile(new MemberProfile()));
            builder.Services.AddAutoMapper(M => M.AddProfile(new BorrowProfile()));

            var app = builder.Build();
            //Seeder

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Library_ManagmentDbContext>();

                context.Database.Migrate();
                DbInitializer.Seed(context);
            }

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
