namespace TodoListApp.WebApp.Data.Entities;

/// <summary>
/// Represents a to-do list that groups related tasks.
/// </summary>
public class TodoList
{
    /// <summary>
    /// Gets or sets the unique identifier of the to-do list.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the short title of the to-do list.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the to-do list.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the user who owns the to-do list.
    /// </summary>
    public string OwnerId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the tasks that belong to this to-do list.
    /// </summary>
    public ICollection<TodoTask> Tasks { get; } = new List<TodoTask>();
}
