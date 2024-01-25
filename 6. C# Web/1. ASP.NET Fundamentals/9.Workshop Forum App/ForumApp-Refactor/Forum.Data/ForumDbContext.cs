using Forum.Data.Configuration;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data;

public class ForumDbContext : DbContext
{
	public ForumDbContext(DbContextOptions<ForumDbContext> options)
		: base(options)
	{
	}

	public DbSet<Post> Posts { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

		modelBuilder.Entity<Post>().HasKey(p => p.PostId);
		
		base.OnModelCreating(modelBuilder);
	}
}
