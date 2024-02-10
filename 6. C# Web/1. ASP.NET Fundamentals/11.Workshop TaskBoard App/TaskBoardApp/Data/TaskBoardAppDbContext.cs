using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Models;
using Task = TaskBoardApp.Models.Task;

namespace TaskBoardApp.Data
{
	public class TaskBoardAppDbContext : IdentityDbContext
	{
		public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Task> Tasks { get; set; } = null!;

		public DbSet<Board> Boards { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<Task>()
				.HasOne(t => t.Board)
				.WithMany(b => b.Tasks)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
		}
	}
}
