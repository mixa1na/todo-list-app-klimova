namespace TodoListApp.WebApp.Data.Entities;

/// <summary>
/// Represents a text label that can be associated with tasks.
/// </summary>
public class Tag
{
    /// <summary>
    /// Gets or sets the unique identifier of the tag.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the tag.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the task-tag associations for the tag.
    /// </summary>
    public ICollection<TodoTaskTag> TodoTaskTags { get; } = new List<TodoTaskTag>();
}
