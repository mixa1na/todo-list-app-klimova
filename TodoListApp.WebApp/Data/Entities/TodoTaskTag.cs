namespace TodoListApp.WebApp.Data.Entities;

/// <summary>
/// Represents the many-to-many association between a task and a tag.
/// </summary>
public class TodoTaskTag
{
    /// <summary>
    /// Gets or sets the identifier of the related task.
    /// </summary>
    public int TodoTaskId { get; set; }

    /// <summary>
    /// Gets or sets the related task.
    /// </summary>
    public TodoTask TodoTask { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier of the related tag.
    /// </summary>
    public int TagId { get; set; }

    /// <summary>
    /// Gets or sets the related tag.
    /// </summary>
    public Tag Tag { get; set; } = null!;
}
