using Microsoft.EntityFrameworkCore;
using TodoListApp.WebApp.Data.Entities;

namespace TodoListApp.WebApp.Data;

/// <summary>
/// Entity Framework Core database context for the to-do list application.
/// </summary>
public class TodoListDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoListDbContext"/> class.
    /// </summary>
    /// <param name="options">The options used to configure the context.</param>
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the to-do lists stored in the database.
    /// </summary>
    public DbSet<TodoList> TodoLists => this.Set<TodoList>();

    /// <summary>
    /// Gets the tasks stored in the database.
    /// </summary>
    public DbSet<TodoTask> TodoTasks => this.Set<TodoTask>();

    /// <summary>
    /// Gets the tags stored in the database.
    /// </summary>
    public DbSet<Tag> Tags => this.Set<Tag>();

    /// <summary>
    /// Gets the comments stored in the database.
    /// </summary>
    public DbSet<Comment> Comments => this.Set<Comment>();

    /// <summary>
    /// Gets the task-tag associations stored in the database.
    /// </summary>
    public DbSet<TodoTaskTag> TodoTaskTags => this.Set<TodoTaskTag>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);

        ConfigureEntities(modelBuilder);
        SeedData(modelBuilder);
    }

    private static void ConfigureEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(todoList => todoList.Id);
            entity.Property(todoList => todoList.Title).IsRequired().HasMaxLength(200);
            entity.Property(todoList => todoList.Description).IsRequired().HasMaxLength(2000);
            entity.Property(todoList => todoList.OwnerId).IsRequired().HasMaxLength(450);
        });

        modelBuilder.Entity<TodoTask>(entity =>
        {
            entity.HasKey(task => task.Id);
            entity.Property(task => task.Title).IsRequired().HasMaxLength(200);
            entity.Property(task => task.Description).IsRequired().HasMaxLength(2000);
            entity.Property(task => task.AssigneeId).IsRequired().HasMaxLength(450);
            entity.Property(task => task.Status).HasConversion<string>().HasMaxLength(32);
            entity.HasOne(task => task.TodoList)
                .WithMany(todoList => todoList.Tasks)
                .HasForeignKey(task => task.TodoListId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(tag => tag.Id);
            entity.Property(tag => tag.Name).IsRequired().HasMaxLength(100);
            entity.HasIndex(tag => tag.Name).IsUnique();
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(comment => comment.Id);
            entity.Property(comment => comment.Text).IsRequired().HasMaxLength(2000);
            entity.Property(comment => comment.AuthorId).IsRequired().HasMaxLength(450);
            entity.HasOne(comment => comment.TodoTask)
                .WithMany(task => task.Comments)
                .HasForeignKey(comment => comment.TodoTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TodoTaskTag>(entity =>
        {
            entity.HasKey(todoTaskTag => new { todoTaskTag.TodoTaskId, todoTaskTag.TagId });
            entity.HasOne(todoTaskTag => todoTaskTag.TodoTask)
                .WithMany(task => task.TodoTaskTags)
                .HasForeignKey(todoTaskTag => todoTaskTag.TodoTaskId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(todoTaskTag => todoTaskTag.Tag)
                .WithMany(tag => tag.TodoTaskTags)
                .HasForeignKey(todoTaskTag => todoTaskTag.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>().HasData(
            new TodoList
            {
                Id = 1,
                Title = "Personal errands",
                Description = "Everyday personal tasks and reminders.",
                OwnerId = "seed-user-1",
            },
            new TodoList
            {
                Id = 2,
                Title = "Work projects",
                Description = "Tasks related to current work assignments.",
                OwnerId = "seed-user-1",
            },
            new TodoList
            {
                Id = 3,
                Title = "Learning goals",
                Description = "Study plan for ASP.NET Core and Entity Framework.",
                OwnerId = "seed-user-2",
            });

        modelBuilder.Entity<TodoTask>().HasData(
            new TodoTask
            {
                Id = 1,
                Title = "Buy groceries",
                Description = "Milk, bread, eggs, and vegetables.",
                CreatedDate = new DateTime(2026, 11, 1, 9, 0, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 2, 18, 0, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.NotStarted,
                AssigneeId = "seed-user-1",
                TodoListId = 1,
            },
            new TodoTask
            {
                Id = 2,
                Title = "Prepare status report",
                Description = "Summarize sprint progress for the weekly meeting.",
                CreatedDate = new DateTime(2026, 11, 3, 10, 0, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 5, 17, 0, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.InProgress,
                AssigneeId = "seed-user-1",
                TodoListId = 2,
            },
            new TodoTask
            {
                Id = 3,
                Title = "Complete EF Core module",
                Description = "Finish migrations, seeding, and DbContext configuration.",
                CreatedDate = new DateTime(2026, 11, 4, 8, 30, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 10, 23, 59, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.Completed,
                AssigneeId = "seed-user-2",
                TodoListId = 3,
            });

        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 1, Name = "urgent" },
            new Tag { Id = 2, Name = "home" },
            new Tag { Id = 3, Name = "study" });

        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                Text = "Do not forget oat milk.",
                CreatedDate = new DateTime(2026, 11, 1, 10, 15, 0, DateTimeKind.Utc),
                AuthorId = "seed-user-1",
                TodoTaskId = 1,
            },
            new Comment
            {
                Id = 2,
                Text = "Include charts for completed stories.",
                CreatedDate = new DateTime(2026, 11, 3, 11, 0, 0, DateTimeKind.Utc),
                AuthorId = "seed-user-1",
                TodoTaskId = 2,
            },
            new Comment
            {
                Id = 3,
                Text = "Migration applied successfully on LocalDB.",
                CreatedDate = new DateTime(2026, 11, 4, 12, 45, 0, DateTimeKind.Utc),
                AuthorId = "seed-user-2",
                TodoTaskId = 3,
            });

        modelBuilder.Entity<TodoTaskTag>().HasData(
            new TodoTaskTag { TodoTaskId = 1, TagId = 2 },
            new TodoTaskTag { TodoTaskId = 2, TagId = 1 },
            new TodoTaskTag { TodoTaskId = 3, TagId = 3 });
    }
}
