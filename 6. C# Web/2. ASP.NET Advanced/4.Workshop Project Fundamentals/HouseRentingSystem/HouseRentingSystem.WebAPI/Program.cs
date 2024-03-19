using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<HouseRentingDbContext>(opt =>
				opt.UseSqlServer(connectionString));

			// Add services to the container.
			builder.Services.AddApplicationServices(typeof(IHouseService));

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(setupAction =>
			{
				setupAction.AddPolicy("HouseRentingSystem", policyBuilder =>
				{
					policyBuilder
					.WithOrigins("https://localhost:7292")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.UseCors("HouseRentingSystem");

			app.Run();
		}
	}
}
