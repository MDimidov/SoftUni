using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

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


		private IdentityUser TestUser { get; set; } = null!;

		private Board OpenBoard { get; set; } = null!;

		private Board InProgressBoard { get; set; } = null!;

		private Board DoneBoard { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{

			builder
				.Entity<Task>()
				.HasOne(t => t.Board)
				.WithMany(b => b.Tasks)
				.OnDelete(DeleteBehavior.Restrict);

			SeedUsers();
			builder
				.Entity<IdentityUser>()
					.HasData(TestUser);

			SeedBoard();
			builder
				.Entity<Board>()
					.HasData(OpenBoard, InProgressBoard, DoneBoard);

			builder
				.Entity<Task>()
					.HasData(new Task
					{
						Id = 1,
						Title = "Improve CSS Styles",
						Decription = "Implement better styling for all public pages",
						CreatedOn = DateTime.Now.AddDays(-200),
						OwnerId = TestUser.Id,
						BoardId = OpenBoard.Id
					},
					new Task
					{
						Id = 2,
						Title = "Android Client App",
						Decription = "Create Android client app for the TaskBoard RESTful API",
						CreatedOn = DateTime.Now.AddMonths(-5),
						OwnerId = TestUser.Id,
						BoardId = OpenBoard.Id
					},
					new Task
					{
						Id = 3,
						Title = "Desctop Client App",
						Decription = "Create Windows Forms app for the TaskBoard RESTful API",
						CreatedOn = DateTime.Now.AddMonths(-1),
						OwnerId = TestUser.Id,
						BoardId = InProgressBoard.Id
					},
					new Task
					{
						Id = 4,
						Title = "Create Tasks",
						Decription = "Implement [Create Task] page for adding new tasks",
						CreatedOn = DateTime.Now.AddYears(-1),
						OwnerId = TestUser.Id,
						BoardId = DoneBoard.Id
					});

			base.OnModelCreating(builder);
		}

		private void SeedBoard()
		{
			OpenBoard = new Board()
			{
				Id = 1,
				Name = "Open",
			};

			InProgressBoard = new Board()
			{
				Id = 2,
				Name = "In Progress"
			};

			DoneBoard = new Board()
			{
				Id = 3,
				Name = "Done"
			};
		}

		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			TestUser = new IdentityUser()
			{
				UserName = "test@softuni.bg",
				NormalizedUserName = "TEST@SOFTUNI.BG",
			};

			TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
		}
	}
}
