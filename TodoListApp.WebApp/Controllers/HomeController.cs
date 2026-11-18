using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Controllers;

/// <summary>
/// Handles home page and error views for the web application.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Shows the application home page.
    /// </summary>
    /// <returns>The home page view.</returns>
    public IActionResult Index()
    {
        return this.View();
    }

    /// <summary>
    /// Shows the privacy policy page.
    /// </summary>
    /// <returns>The privacy page view.</returns>
    public IActionResult Privacy()
    {
        return this.View();
    }

    /// <summary>
    /// Shows the error page.
    /// </summary>
    /// <returns>The error page view.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
