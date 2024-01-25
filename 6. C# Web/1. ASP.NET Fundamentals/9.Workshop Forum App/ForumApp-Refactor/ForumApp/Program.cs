using Forum.Data;
using Forum.Services;
using Forum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForumApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var conncentionString = builder
				.Configuration
				.GetConnectionString("DefaultConnection");

			builder
				.Services
				.AddDbContext<ForumDbContext>(
				   options => options.UseSqlServer(conncentionString));

			// Add custom service
			builder.Services.AddScoped<IPostService, PostService>();

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
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}