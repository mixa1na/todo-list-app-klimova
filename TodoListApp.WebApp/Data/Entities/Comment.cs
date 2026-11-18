namespace TodoListApp.WebApp.Data.Entities;

/// <summary>
/// Represents a text note added to a task.
/// </summary>
public class Comment
{
    /// <summary>
    /// Gets or sets the unique identifier of the comment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the comment text.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the comment was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who authored the comment.
    /// </summary>
    public string AuthorId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the related task.
    /// </summary>
    public int TodoTaskId { get; set; }

    /// <summary>
    /// Gets or sets the related task.
    /// </summary>
    public TodoTask TodoTask { get; set; } = null!;
}
