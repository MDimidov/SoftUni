#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data;

public class TaskBoardAppDbContext : IdentityDbContext
{
    public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Data.Models.Task> Tasks { get; set; }

    public DbSet<Board> Boards { get; set; }


    private IdentityUser TestUser { get; set; } = null!;

    private Board OpenBoard { get; set; } = null!;

    private Board InProgressBoard { get; set; } = null!;

    private Board DoneBoard { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Data.Models.Task>()
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
            .Entity<Data.Models.Task>()
                .HasData(new Data.Models.Task
                {
                    Id = 1,
                    Title = "Improve CSS Styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Data.Models.Task
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Data.Models.Task
                {
                    Id = 3,
                    Title = "Desctop Client App",
                    Description = "Create Windows Forms app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Data.Models.Task
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
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
