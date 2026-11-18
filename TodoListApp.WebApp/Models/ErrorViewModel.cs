namespace TodoListApp.WebApp.Models;

/// <summary>
/// Represents data displayed on the error page.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Gets or sets the request identifier associated with the error.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether the request identifier should be shown.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
}
