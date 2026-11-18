namespace TodoListApp.WebApp.Data.Entities;

/// <summary>
/// Represents a task that belongs to a to-do list.
/// </summary>
public class TodoTask
{
    /// <summary>
    /// Gets or sets the unique identifier of the task.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the task.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the task.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the task was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the due date of the task.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Gets or sets the current status of the task.
    /// </summary>
    public TodoTaskStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user assigned to the task.
    /// </summary>
    public string AssigneeId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the parent to-do list.
    /// </summary>
    public int TodoListId { get; set; }

    /// <summary>
    /// Gets or sets the parent to-do list.
    /// </summary>
    public TodoList TodoList { get; set; } = null!;

    /// <summary>
    /// Gets the comments added to the task.
    /// </summary>
    public ICollection<Comment> Comments { get; } = new List<Comment>();

    /// <summary>
    /// Gets the task-tag associations for the task.
    /// </summary>
    public ICollection<TodoTaskTag> TodoTaskTags { get; } = new List<TodoTaskTag>();
}
